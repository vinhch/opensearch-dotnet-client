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
// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//
// This file is automatically generated
// Please do not edit these files manually
// Run the following in the root of the repos:
//
//      *NIX        :   ./build.sh codegen
//      Windows     :   build.bat codegen
//
// -----------------------------------------------

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenSearch.Net.Specification.KnnApi
{
    /// <summary>Request options for DeleteModel <para>https://opensearch.org/docs/latest/search-plugins/knn/api/#delete-model</para></summary>
    public partial class DeleteModelRequestParameters
        : RequestParameters<DeleteModelRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
        public override bool SupportsBody => false;
    }

    /// <summary>Request options for GetModel <para>https://opensearch.org/docs/latest/search-plugins/knn/api/#get-model</para></summary>
    public partial class GetModelRequestParameters : RequestParameters<GetModelRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
        public override bool SupportsBody => false;
    }

    /// <summary>Request options for SearchModels <para>https://opensearch.org/docs/latest/search-plugins/knn/api/#search-model</para></summary>
    public partial class SearchModelsRequestParameters
        : RequestParameters<SearchModelsRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
        public override bool SupportsBody => true;

        /// <summary>
        /// Whether to ignore if a wildcard indexes expression resolves into no concrete indexes. (This includes `_all` string or when no indexes have
        /// been specified).
        /// </summary>
        public bool? AllowNoIndices
        {
            get => Q<bool?>("allow_no_indices");
            set => Q("allow_no_indices", value);
        }

        /// <summary>Indicate if an error should be returned if there is a partial search failure or timeout.</summary>
        public bool? AllowPartialSearchResults
        {
            get => Q<bool?>("allow_partial_search_results");
            set => Q("allow_partial_search_results", value);
        }

        /// <summary>The analyzer to use for the query string.</summary>
        public string Analyzer
        {
            get => Q<string>("analyzer");
            set => Q("analyzer", value);
        }

        /// <summary>Specify whether wildcard and prefix queries should be analyzed.</summary>
        public bool? AnalyzeWildcard
        {
            get => Q<bool?>("analyze_wildcard");
            set => Q("analyze_wildcard", value);
        }

        /// <summary>
        /// The number of shard results that should be reduced at once on the coordinating node. This value should be used as a protection mechanism
        /// to reduce the memory overhead per search request if the potential number of shards in the request can be large.
        /// </summary>
        public int? BatchedReduceSize
        {
            get => Q<int?>("batched_reduce_size");
            set => Q("batched_reduce_size", value);
        }

        /// <summary>Indicates whether network round-trips should be minimized as part of cross-cluster search requests execution.</summary>
        public bool? CcsMinimizeRoundtrips
        {
            get => Q<bool?>("ccs_minimize_roundtrips");
            set => Q("ccs_minimize_roundtrips", value);
        }

        /// <summary>The default operator for query string query (AND or OR).</summary>
        public KnnDefaultOperator? DefaultOperator
        {
            get => Q<KnnDefaultOperator?>("default_operator");
            set => Q("default_operator", value);
        }

        /// <summary>The field to use as default where no field prefix is given in the query string.</summary>
        public string Df
        {
            get => Q<string>("df");
            set => Q("df", value);
        }

        /// <summary>Comma-separated list of fields to return as the docvalue representation of a field for each hit.</summary>
        public string[] DocValueFields
        {
            get => Q<string[]>("docvalue_fields");
            set => Q("docvalue_fields", value);
        }

        /// <summary>Whether to expand wildcard expression to concrete indexes that are open, closed or both.</summary>
        public ExpandWildcards? ExpandWildcards
        {
            get => Q<ExpandWildcards?>("expand_wildcards");
            set => Q("expand_wildcards", value);
        }

        /// <summary>Specify whether to return detailed information about score computation as part of a hit.</summary>
        public bool? Explain
        {
            get => Q<bool?>("explain");
            set => Q("explain", value);
        }

        /// <summary>Starting offset.</summary>
        public int? From
        {
            get => Q<int?>("from");
            set => Q("from", value);
        }

        /// <summary>Whether specified concrete, expanded or aliased indexes should be ignored when throttled.</summary>
        public bool? IgnoreThrottled
        {
            get => Q<bool?>("ignore_throttled");
            set => Q("ignore_throttled", value);
        }

        /// <summary>Whether specified concrete indexes should be ignored when unavailable (missing or closed).</summary>
        public bool? IgnoreUnavailable
        {
            get => Q<bool?>("ignore_unavailable");
            set => Q("ignore_unavailable", value);
        }

        /// <summary>Specify whether format-based query failures (such as providing text to a numeric field) should be ignored.</summary>
        public bool? Lenient
        {
            get => Q<bool?>("lenient");
            set => Q("lenient", value);
        }

        /// <summary>
        /// The number of concurrent shard requests per node this search executes concurrently. This value should be used to limit the impact of the
        /// search on the cluster in order to limit the number of concurrent shard requests.
        /// </summary>
        public int? MaxConcurrentShardRequests
        {
            get => Q<int?>("max_concurrent_shard_requests");
            set => Q("max_concurrent_shard_requests", value);
        }

        /// <summary>Specify the node or shard the operation should be performed on.</summary>
        public string Preference
        {
            get => Q<string>("preference");
            set => Q("preference", value);
        }

        /// <summary>
        /// Threshold that enforces a pre-filter round-trip to prefilter search shards based on query rewriting if the number of shards the search
        /// request expands to exceeds the threshold. This filter round-trip can limit the number of shards significantly if for instance a shard can
        /// not match any documents based on its rewrite method, that is if date filters are mandatory to match but the shard bounds and the query are
        /// disjoint.
        /// </summary>
        public int? PreFilterShardSize
        {
            get => Q<int?>("pre_filter_shard_size");
            set => Q("pre_filter_shard_size", value);
        }

        /// <summary>Query in the Lucene query string syntax.</summary>
        public string QueryOnQueryString
        {
            get => Q<string>("q");
            set => Q("q", value);
        }

        /// <summary>Specify if request cache should be used for this request or not, defaults to index level setting.</summary>
        public bool? RequestCache
        {
            get => Q<bool?>("request_cache");
            set => Q("request_cache", value);
        }

        /// <summary>Comma-separated list of specific routing values.</summary>
        public string[] Routing
        {
            get => Q<string[]>("routing");
            set => Q("routing", value);
        }

        /// <summary>Specify how long a consistent view of the index should be maintained for scrolled search.</summary>
        public TimeSpan Scroll
        {
            get => Q<TimeSpan>("scroll");
            set => Q("scroll", value);
        }

        /// <summary>Search operation type.</summary>
        public KnnSearchType? SearchType
        {
            get => Q<KnnSearchType?>("search_type");
            set => Q("search_type", value);
        }

        /// <summary>Specify whether to return sequence number and primary term of the last modification of each hit.</summary>
        public bool? SequenceNumberPrimaryTerm
        {
            get => Q<bool?>("seq_no_primary_term");
            set => Q("seq_no_primary_term", value);
        }

        /// <summary>Number of hits to return.</summary>
        public int? Size
        {
            get => Q<int?>("size");
            set => Q("size", value);
        }

        /// <summary>Comma-separated list of &lt;field&gt;:&lt;direction&gt; pairs.</summary>
        public string[] Sort
        {
            get => Q<string[]>("sort");
            set => Q("sort", value);
        }

        /// <summary>Set to `true` or `false` to return the `_source` field or not, or a list of fields to return.</summary>
        public bool? SourceEnabled
        {
            get => Q<bool?>("_source");
            set => Q("_source", value);
        }

        /// <summary>List of fields to exclude from the returned `_source` field.</summary>
        public string[] SourceExcludes
        {
            get => Q<string[]>("_source_excludes");
            set => Q("_source_excludes", value);
        }

        /// <summary>List of fields to extract and return from the `_source` field.</summary>
        public string[] SourceIncludes
        {
            get => Q<string[]>("_source_includes");
            set => Q("_source_includes", value);
        }

        /// <summary>Specific 'tag' of the request for logging and statistical purposes.</summary>
        public string[] Stats
        {
            get => Q<string[]>("stats");
            set => Q("stats", value);
        }

        /// <summary>Comma-separated list of stored fields to return.</summary>
        public string[] StoredFields
        {
            get => Q<string[]>("stored_fields");
            set => Q("stored_fields", value);
        }

        /// <summary>Specify which field to use for suggestions.</summary>
        public string SuggestField
        {
            get => Q<string>("suggest_field");
            set => Q("suggest_field", value);
        }

        /// <summary>Specify suggest mode.</summary>
        public KnnSuggestMode? SuggestMode
        {
            get => Q<KnnSuggestMode?>("suggest_mode");
            set => Q("suggest_mode", value);
        }

        /// <summary>How many suggestions to return in response.</summary>
        public int? SuggestSize
        {
            get => Q<int?>("suggest_size");
            set => Q("suggest_size", value);
        }

        /// <summary>The source text for which the suggestions should be returned.</summary>
        public string SuggestText
        {
            get => Q<string>("suggest_text");
            set => Q("suggest_text", value);
        }

        /// <summary>The maximum number of documents to collect for each shard, upon reaching which the query execution will terminate early.</summary>
        public int? TerminateAfter
        {
            get => Q<int?>("terminate_after");
            set => Q("terminate_after", value);
        }

        /// <summary>Operation timeout.</summary>
        public TimeSpan Timeout
        {
            get => Q<TimeSpan>("timeout");
            set => Q("timeout", value);
        }

        /// <summary>Indicates whether `hits.total` should be rendered as an integer or an object in the rest search response.</summary>
        public bool? TotalHitsAsInteger
        {
            get => Q<bool?>("rest_total_hits_as_int");
            set => Q("rest_total_hits_as_int", value);
        }

        /// <summary>Whether to calculate and return scores even if they are not used for sorting.</summary>
        public bool? TrackScores
        {
            get => Q<bool?>("track_scores");
            set => Q("track_scores", value);
        }

        /// <summary>Indicate if the number of documents that match the query should be tracked.</summary>
        public bool? TrackTotalHits
        {
            get => Q<bool?>("track_total_hits");
            set => Q("track_total_hits", value);
        }

        /// <summary>Specify whether aggregation and suggester names should be prefixed by their respective types in the response.</summary>
        public bool? TypedKeys
        {
            get => Q<bool?>("typed_keys");
            set => Q("typed_keys", value);
        }

        /// <summary>Whether to return document version as part of a hit.</summary>
        public bool? Version
        {
            get => Q<bool?>("version");
            set => Q("version", value);
        }
    }

    /// <summary>Request options for Stats <para>https://opensearch.org/docs/latest/search-plugins/knn/api/#stats</para></summary>
    public partial class StatsRequestParameters : RequestParameters<StatsRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
        public override bool SupportsBody => false;

        /// <summary>Operation timeout.</summary>
        public TimeSpan Timeout
        {
            get => Q<TimeSpan>("timeout");
            set => Q("timeout", value);
        }
    }

    /// <summary>Request options for TrainModel <para>https://opensearch.org/docs/latest/search-plugins/knn/api/#train-model</para></summary>
    public partial class TrainModelRequestParameters
        : RequestParameters<TrainModelRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
        public override bool SupportsBody => true;

        /// <summary>Preferred node to execute training.</summary>
        public string Preference
        {
            get => Q<string>("preference");
            set => Q("preference", value);
        }
    }

    /// <summary>Request options for Warmup <para>https://opensearch.org/docs/latest/search-plugins/knn/api/#warmup-operation</para></summary>
    public partial class WarmupRequestParameters : RequestParameters<WarmupRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
        public override bool SupportsBody => false;
    }
}
