/* SPDX-License-Identifier: Apache-2.0
*
* The OpenSearch Contributors require contributions made to
* this file be licensed under the Apache-2.0 license or a
* compatible open source license.
*/
/*
* Modifications Copyright OpenSearch Contributors. See
* GitHub history for details.
*
*  Licensed to Elasticsearch B.V. under one or more contributor
*  license agreements. See the NOTICE file distributed with
*  this work for additional information regarding copyright
*  ownership. Elasticsearch B.V. licenses this file to you under
*  the Apache License, Version 2.0 (the "License"); you may
*  not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*   http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing,
*  software distributed under the License is distributed on an
*  "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
*  KIND, either express or implied.  See the License for the
*  specific language governing permissions and limitations
*  under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using ApiGenerator.Configuration;
using ApiGenerator.Configuration.Overrides;
using ApiGenerator.Domain;
using ApiGenerator.Domain.Code;
using ApiGenerator.Domain.Specification;
using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax.Inlines;
using NJsonSchema;
using NJsonSchema.References;
using NSwag;
using Version = SemanticVersioning.Version;

namespace ApiGenerator.Generator
{
    public static class ApiEndpointFactory
    {
        public static ApiEndpoint From(
            string name,
            List<(string HttpPath, OpenApiPathItem Path, string HttpMethod, OpenApiOperation Operation)> variants,
            Action<string, bool> trackEnumToGenerate
        )
        {
            var tokens = name.Split(".");
            var methodName = tokens[^1];
            var ns = tokens.Length > 1 ? tokens[0] : null;
            var names = new CsharpNames(name, methodName, ns);
            var overrides = LoadOverrides(name, names.MethodName);

            HashSet<string> requiredPathParts = null;
            var allParts = new Dictionary<string, UrlPart>();
            var canonicalPaths = new Dictionary<HashSet<string>, UrlPath>(HashSet<string>.CreateSetComparer());
            var deprecatedPaths = new Dictionary<HashSet<string>, UrlPath>(HashSet<string>.CreateSetComparer());

            var httpPathVariants = variants
                .DistinctBy(v => v.HttpPath)
                .Select(v =>
                    (
                        v.HttpPath, v.Operation,
                        PathParams: v.Path.Parameters
                            .Concat(v.Operation.Parameters)
                            .Select(p => p.ActualParameter)
                            .Where(p => p.Kind == OpenApiParameterKind.Path)
                            .ToList()
                    )
                )
                .OrderBy(v => v.PathParams.Count(p => p.IsOverloaded()))
                .SelectMany(v => GetOverloadedPathVariants(v.HttpPath, v.PathParams).Select(p => (p.HttpPath, v.Operation, p.PathParameters)));

            foreach (var (httpPath, operation, pathParams) in httpPathVariants)
            {
                var parts = new List<UrlPart>();
                var partNames = new HashSet<string>();

                foreach (var (paramName, schema, description, isDeprecated) in pathParams)
                {
                    if (!allParts.TryGetValue(paramName, out var part))
                    {
                        var type = GetOpenSearchType(schema, trackEnumToGenerate);
                        part = allParts[paramName] = new UrlPart
                        {
                            ClrTypeNameOverride = null,
                            Deprecated = isDeprecated,
                            Description = description?.SanitizeDescription(),
                            Name = paramName,
                            Type = type
                        };
                    }
                    partNames.Add(paramName);
                    parts.Add(part);
                }

                parts.SortBy(p => httpPath.IndexOf($"{{{p.Name}}}", StringComparison.Ordinal));

                var urlPath = new UrlPath(httpPath, parts, GetDeprecation(operation), operation.XVersionAdded());
                (urlPath.Deprecation == null ? canonicalPaths : deprecatedPaths).TryAdd(partNames, urlPath);

                if (requiredPathParts != null)
                    requiredPathParts.IntersectWith(partNames);
                else
                    requiredPathParts = partNames;
            }

            //some deprecated paths describe aliases to the canonical using the same path e.g
            // PUT /{index}/_mapping/{type}
            // PUT /{index}/{type}/_mappings
            //
            //The following routine dedups these occasions and prefers either the canonical path
            //or the first duplicate deprecated path

            var paths = canonicalPaths.Values
                .Concat(deprecatedPaths
                    .Where(p => !canonicalPaths.ContainsKey(p.Key))
                    .Select(p => p.Value))
                .ToList();

            ApiRequestParametersPatcher.PatchUrlPaths(name, paths, overrides);

            paths.SortBy(p => string.Join(",", p.Parts.Select(part => part.Name)));

            foreach (var partName in requiredPathParts ?? Enumerable.Empty<string>()) allParts[partName].Required = true;

            IDictionary<string, QueryParameters> queryParams = variants.SelectMany(v => v.Path.Parameters.Concat(v.Operation.Parameters))
                .Select(p => p.ActualParameter)
                .Where(p => p.Kind == OpenApiParameterKind.Query && !p.XGlobal())
                .DistinctBy(p => p.Name)
                .ToDictionary(p => p.Name, p => BuildQueryParam(p, trackEnumToGenerate));
            queryParams = ApiRequestParametersPatcher.PatchQueryParameters(name, queryParams, overrides);

            Body body = null;
            if (variants.Select(v => v.Operation.RequestBody).FirstOrDefault() is { } requestBody)
                body = new Body { Description = requestBody.GetDescription()?.SanitizeDescription(), Required = requestBody.IsRequired };

            return new ApiEndpoint
            {
                Name = name,
                Namespace = ns,
                MethodName = methodName,
                CsharpNames = names,
                Overrides = overrides,
                Stability = Stability.Stable, // TODO: for realsies
                OfficialDocumentationLink =
                    new Documentation
                    {
                        Description = variants[0].Operation.Description?.SanitizeDescription(),
                        Url = variants[0].Operation.ExternalDocumentation?.Url
                    },
                Url = new UrlInformation { AllPaths = paths, Params = queryParams },
                Body = body,
                HttpMethods = variants.Select(v => v.HttpMethod.ToString().ToUpper()).Distinct().ToList(),
            };
        }

        private static IEnumerable<(string HttpPath, List<PathParameter> PathParameters)> GetOverloadedPathVariants(
            string originalHttpPath, List<OpenApiParameter> pathParams
        )
        {
            var paramCount = pathParams.Count;

            return GenerateVariants(originalHttpPath, 0, new List<PathParameter>());

            IEnumerable<(string HttpPath, List<PathParameter> PathParameters)> GenerateVariants(string variantHttpPath, int i,
                List<PathParameter> paramCombo
            )
            {
                if (i == paramCount) return [(variantHttpPath, paramCombo)];

                var originalParameter = pathParams[i];
                var overloads = !originalParameter.IsOverloaded()
                    ? [(variantHttpPath, new PathParameter(originalParameter))]
                    : originalParameter.Schema.AnyOf
                        .Select(overload =>
                            (
                                HttpPath: variantHttpPath.Replace($"{{{originalParameter.Name}}}", $"{{{overload.Title}}}"),
                                PathParameter: new PathParameter(overload.Title, originalParameter, overload)
                            )
                        );

                return overloads.SelectMany(o => GenerateVariants(o.HttpPath, i + 1, [..paramCombo, o.PathParameter]));
            }
        }

        private record PathParameter(string Name, JsonSchema Schema, string Description, bool IsDeprecated)
        {
            public PathParameter(OpenApiParameter parameter) :
                this(parameter.Name, parameter.Schema, parameter.GetDescription(), parameter.IsDeprecated) { }

            public PathParameter(string name, OpenApiParameter parameter, JsonSchema schema) : this(name, schema, parameter.GetDescription(),
                parameter.IsDeprecated) { }
        }

        private static IEndpointOverrides LoadOverrides(string endpointName, string methodName)
        {
            if (CodeConfiguration.ApiNameMapping.TryGetValue(endpointName, out var mapsApiMethodName))
                methodName = mapsApiMethodName;

            var namespacePrefix = $"{typeof(GlobalOverrides).Namespace}.Endpoints.";
            var typeName = $"{namespacePrefix}{methodName}Overrides";
            var type = GeneratorLocations.Assembly.GetType(typeName);

            return type != null && Activator.CreateInstance(type) is IEndpointOverrides overrides ? overrides : null;
        }

        private static QueryParameters BuildQueryParam(OpenApiParameter p, Action<string, bool> trackEnumToGenerate) =>
            new()
            {
                Type = GetOpenSearchType(p.Schema, trackEnumToGenerate),
                Description = p.GetDescription()?.SanitizeDescription(),
                Deprecated = GetDeprecation(p) ?? GetDeprecation(p.ActualSchema),
                VersionAdded = p.XVersionAdded(),
            };

        private static string GetOpenSearchType(JsonSchema schema, Action<string, bool> trackEnumToGenerate, bool isListContext = false)
        {
            var schemaKey = ((IJsonReference)schema).ReferencePath?.Split('/').Last();
            schema = schema.ActualSchema;

            if (schemaKey != null && schema.IsEnum())
            {
                trackEnumToGenerate(schemaKey, isListContext);
                return CsharpNames.GetEnumName(schemaKey) + "?";
            }

            if (schema.OneOf.Count > 0 || schema.AnyOf.Count > 0)
            {
                var oneOf = (schema.OneOf.Count > 0 ? schema.OneOf : schema.AnyOf).ToArray();

                if (oneOf.Length != 2) throw new Exception("Unable to determine type of oneOf");

                var first = GetOpenSearchType(oneOf[0], trackEnumToGenerate);
                var second = GetOpenSearchType(oneOf[1], trackEnumToGenerate);
                if (first.EndsWith("?")) return first;
                if (first == second) return first;

                return (first, second) switch
                {
                    (_, "list") => second,
                    ("boolean", "string") => first,
                    ("int", _) => "string",
                    (_, "double") => "string",
                    (_, "int") => "string",
                    ("string", _) => "string",
                    (_, _) => throw new Exception($"Unable to determine type of: {first} and {second}")
                };
            }

            if (schema.Type == JsonObjectType.Array && (schema.Item?.HasReference ?? false))
                _ = GetOpenSearchType(schema.Item, trackEnumToGenerate, true);

            var types = Enum.GetValues<JsonObjectType>()
                .Where(t => t != JsonObjectType.None && t != JsonObjectType.Null && schema.Type.HasFlag(t))
                .ToHashSet();

            var type = types.Count switch
            {
                0 => throw new Exception("No type specified"),
                1 => types.First(),
                2 when types.Contains(JsonObjectType.Boolean) && types.Contains(JsonObjectType.String) => JsonObjectType.String,
                _ => throw new Exception($"Unable to determine type of: {string.Join(", ", types)}")
            };

            return type switch
            {
                JsonObjectType.Integer when schema.Format is null or "int32" => "int",
                JsonObjectType.Integer when schema.Format == "int64" => "long",
                JsonObjectType.Number => schema.Format ?? "double",
                JsonObjectType.Array => "list",
                JsonObjectType.String when schema.Pattern == @"^(?:(-1)|([0-9\.]+)(?:d|h|m|s|ms|micros|nanos))$" => "time",
                var t => t.ToString().ToLowerInvariant()
            };
        }

        private static Deprecation GetDeprecation(IJsonExtensionObject schema) =>
            (schema.XDeprecationMessage(), schema.XVersionDeprecated()) switch
            {
                (null, null) => null,
                var (m, v) => new Deprecation { Description = m?.SanitizeDescription(renderMarkdown: false), Version = v }
            };

        private static string GetDescription(this OpenApiRequestBody requestBody)
        {
            if (!string.IsNullOrWhiteSpace(requestBody.Description))
                return requestBody.Description;

            return requestBody.Content.TryGetValue(MediaTypeNames.Application.Json, out var content)
                ? content.Schema?.ActualSchema.Description
                : null;
        }

        private static string GetDescription(this OpenApiParameter parameter) =>
            !string.IsNullOrWhiteSpace(parameter.Description)
                ? parameter.Description
                : parameter.Schema.GetDescription();

        private static string GetDescription(this JsonSchema schema)
        {
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(schema.Description)) return schema.Description;

                if (!schema.HasReference) return null;

                schema = schema.ActualSchema;
            }
        }

        private class MarkdownExtension : IMarkdownExtension
        {
            public void Setup(MarkdownPipelineBuilder pipeline) => pipeline.DisableHtml();

            public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
            {
                if (renderer is HtmlRenderer htmlRenderer)
                {
                    htmlRenderer.ImplicitParagraph = true;
                    htmlRenderer.ObjectRenderers.Insert(0, new CodeInlineRenderer());
                }
            }

            private class CodeInlineRenderer : HtmlObjectRenderer<CodeInline>
            {
                protected override void Write(HtmlRenderer renderer, CodeInline obj)
                {
                    if (renderer.EnableHtmlForInline)
                    {
                        renderer.Write("<c");
                        renderer.WriteAttributes(obj);
                        renderer.Writer.Write('>');
                    }
                    if (renderer.EnableHtmlEscape)
                    {
                        renderer.WriteEscape(obj.ContentSpan);
                    }
                    else
                    {
                        renderer.Write(obj.ContentSpan);
                    }
                    if (renderer.EnableHtmlForInline)
                    {
                        renderer.Writer.Write("</c>");
                    }
                }
            }
        }

        private static readonly MarkdownPipeline MarkdownPipeline = new MarkdownPipelineBuilder()
            .Use<MarkdownExtension>()
            .Build();

        private static string SanitizeDescription(this string description, bool renderMarkdown = true)
        {
            if (string.IsNullOrWhiteSpace(description)) return null;

            description = Regex.Replace(description, @"\s+", " ")
                .Replace("{{site.url}}", "https://opensearch.org")
                .Replace("{{site.baseurl}}", "/docs/latest");

            if (!description.EndsWith('.')) description += '.';

            if (renderMarkdown)
                description = Markdown.ToHtml(description, MarkdownPipeline).TrimEnd('\r', '\n');

            return description;
        }

        private static bool IsOverloaded(this OpenApiParameter parameter) =>
            parameter.Schema.AnyOf.Count > 0 && parameter.Schema.AnyOf.All(s => !s.Title.IsNullOrEmpty());

        private static bool XGlobal(this OpenApiParameter parameter) =>
            parameter.GetExtension("x-global") is string s && bool.Parse(s);

        private static string XDeprecationMessage(this IJsonExtensionObject schema) =>
            schema.GetExtension("x-deprecation-message") as string;

        private static Version XVersionDeprecated(this IJsonExtensionObject schema) =>
            schema.GetExtension("x-version-deprecated") is string s
                ? CoerceVersion(s)
                : null;

        private static Version XVersionAdded(this IJsonExtensionObject schema) =>
            schema.GetExtension("x-version-added") is string s
                ? CoerceVersion(s)
                : null;

        private static Version CoerceVersion(string s) =>
            s.Split('.').Length switch
            {
                1 => new Version($"{s}.0.0"),
                2 => new Version($"{s}.0"),
                _ => new Version(s),
            };
    }
}
