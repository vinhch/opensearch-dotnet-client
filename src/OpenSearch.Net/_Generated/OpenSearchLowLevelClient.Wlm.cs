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
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenSearch.Net;
using static OpenSearch.Net.HttpMethod;

// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable once CheckNamespace
// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable RedundantExtendsListEntry
namespace OpenSearch.Net.Specification.WlmApi
{
    /// <summary>
    /// Wlm APIs.
    /// <para>Not intended to be instantiated directly. Use the <see cref="IOpenSearchLowLevelClient.Wlm"/> property
    /// on <see cref="IOpenSearchLowLevelClient"/>.
    /// </para>
    /// </summary>
    public partial class LowLevelWlmNamespace : NamespacedClientProxy
    {
        internal LowLevelWlmNamespace(OpenSearchLowLevelClient client)
            : base(client) { }

        /// <summary>PUT on /_wlm/query_group</summary>
        /// <param name="body"></param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        public TResponse CreateQueryGroup<TResponse>(
            PostData body,
            CreateQueryGroupRequestParameters requestParameters = null
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequest<TResponse>(PUT, "_wlm/query_group", body, RequestParams(requestParameters));

        /// <summary>PUT on /_wlm/query_group</summary>
        /// <param name="body"></param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        [MapsApi("wlm.create_query_group", "body")]
        public Task<TResponse> CreateQueryGroupAsync<TResponse>(
            PostData body,
            CreateQueryGroupRequestParameters requestParameters = null,
            CancellationToken ctx = default
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequestAsync<TResponse>(
                PUT,
                "_wlm/query_group",
                ctx,
                body,
                RequestParams(requestParameters)
            );

        /// <summary>DELETE on /_wlm/query_group/{name}</summary>
        /// <param name="name">The name of the query group.</param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        public TResponse DeleteQueryGroup<TResponse>(
            string name,
            DeleteQueryGroupRequestParameters requestParameters = null
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequest<TResponse>(
                DELETE,
                Url($"_wlm/query_group/{name:name}"),
                null,
                RequestParams(requestParameters)
            );

        /// <summary>DELETE on /_wlm/query_group/{name}</summary>
        /// <param name="name">The name of the query group.</param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        [MapsApi("wlm.delete_query_group", "name")]
        public Task<TResponse> DeleteQueryGroupAsync<TResponse>(
            string name,
            DeleteQueryGroupRequestParameters requestParameters = null,
            CancellationToken ctx = default
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequestAsync<TResponse>(
                DELETE,
                Url($"_wlm/query_group/{name:name}"),
                ctx,
                null,
                RequestParams(requestParameters)
            );

        /// <summary>GET on /_wlm/query_group</summary>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        public TResponse GetQueryGroup<TResponse>(
            GetQueryGroupRequestParameters requestParameters = null
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequest<TResponse>(GET, "_wlm/query_group", null, RequestParams(requestParameters));

        /// <summary>GET on /_wlm/query_group</summary>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        [MapsApi("wlm.get_query_group", "")]
        public Task<TResponse> GetQueryGroupAsync<TResponse>(
            GetQueryGroupRequestParameters requestParameters = null,
            CancellationToken ctx = default
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequestAsync<TResponse>(
                GET,
                "_wlm/query_group",
                ctx,
                null,
                RequestParams(requestParameters)
            );

        /// <summary>GET on /_wlm/query_group/{name}</summary>
        /// <param name="name">The name of the query group.</param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        public TResponse GetQueryGroup<TResponse>(
            string name,
            GetQueryGroupRequestParameters requestParameters = null
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequest<TResponse>(
                GET,
                Url($"_wlm/query_group/{name:name}"),
                null,
                RequestParams(requestParameters)
            );

        /// <summary>GET on /_wlm/query_group/{name}</summary>
        /// <param name="name">The name of the query group.</param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        [MapsApi("wlm.get_query_group", "name")]
        public Task<TResponse> GetQueryGroupAsync<TResponse>(
            string name,
            GetQueryGroupRequestParameters requestParameters = null,
            CancellationToken ctx = default
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequestAsync<TResponse>(
                GET,
                Url($"_wlm/query_group/{name:name}"),
                ctx,
                null,
                RequestParams(requestParameters)
            );

        /// <summary>PUT on /_wlm/query_group/{name}</summary>
        /// <param name="name">The name of the query group.</param>
        /// <param name="body"></param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        public TResponse UpdateQueryGroup<TResponse>(
            string name,
            PostData body,
            UpdateQueryGroupRequestParameters requestParameters = null
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequest<TResponse>(
                PUT,
                Url($"_wlm/query_group/{name:name}"),
                body,
                RequestParams(requestParameters)
            );

        /// <summary>PUT on /_wlm/query_group/{name}</summary>
        /// <param name="name">The name of the query group.</param>
        /// <param name="body"></param>
        /// <param name="requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
        /// <remarks>Supported by OpenSearch servers of version 2.17.0 or greater.</remarks>
        [MapsApi("wlm.update_query_group", "name, body")]
        public Task<TResponse> UpdateQueryGroupAsync<TResponse>(
            string name,
            PostData body,
            UpdateQueryGroupRequestParameters requestParameters = null,
            CancellationToken ctx = default
        )
            where TResponse : class, IOpenSearchResponse, new() =>
            DoRequestAsync<TResponse>(
                PUT,
                Url($"_wlm/query_group/{name:name}"),
                ctx,
                body,
                RequestParams(requestParameters)
            );
    }
}
