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
using OpenSearch.Net;
using OpenSearch.Net.Specification.NodesApi;
using OpenSearch.Net.Utf8Json;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace OpenSearch.Client
{
    /// <summary>Descriptor for HotThreads <para>https://opensearch.org/docs/latest/api-reference/nodes-apis/nodes-hot-threads/</para></summary>
    public partial class NodesHotThreadsDescriptor
        : RequestDescriptorBase<
            NodesHotThreadsDescriptor,
            NodesHotThreadsRequestParameters,
            INodesHotThreadsRequest
        >,
            INodesHotThreadsRequest
    {
        internal override ApiUrls ApiUrls => ApiUrlsLookups.NodesHotThreads;

        /// <summary>/_nodes/hot_threads</summary>
        public NodesHotThreadsDescriptor()
            : base() { }

        /// <summary>/_nodes/{node_id}/hot_threads</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        public NodesHotThreadsDescriptor(NodeIds nodeId)
            : base(r => r.Optional("node_id", nodeId)) { }

        // values part of the url path
        NodeIds INodesHotThreadsRequest.NodeId => Self.RouteValues.Get<NodeIds>("node_id");

        /// <summary>Comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you're connecting to, leave empty to get information from all nodes.</summary>
        public NodesHotThreadsDescriptor NodeId(NodeIds nodeId) =>
            Assign(nodeId, (a, v) => a.RouteValues.Optional("node_id", v));

        // Request parameters
        /// <summary>Don't show threads that are in known-idle places, such as waiting on a socket select or pulling from an empty task queue.</summary>
        public NodesHotThreadsDescriptor IgnoreIdleThreads(bool? ignoreidlethreads = true) =>
            Qs("ignore_idle_threads", ignoreidlethreads);

        /// <summary>The interval for the second sampling of threads.</summary>
        public NodesHotThreadsDescriptor Interval(Time interval) => Qs("interval", interval);

        /// <summary>Number of samples of thread stack trace.</summary>
        public NodesHotThreadsDescriptor Snapshots(int? snapshots) => Qs("snapshots", snapshots);

        /// <summary>Specify the number of threads to provide information for.</summary>
        public NodesHotThreadsDescriptor Threads(int? threads) => Qs("threads", threads);

        /// <summary>Operation timeout.</summary>
        public NodesHotThreadsDescriptor Timeout(Time timeout) => Qs("timeout", timeout);

        /// <summary>The type to sample.</summary>
        public NodesHotThreadsDescriptor Type(NodesSampleType? type) => Qs("type", type);
    }

    /// <summary>Descriptor for Info <para>https://opensearch.org/docs/latest/api-reference/nodes-apis/nodes-info/</para></summary>
    public partial class NodesInfoDescriptor
        : RequestDescriptorBase<NodesInfoDescriptor, NodesInfoRequestParameters, INodesInfoRequest>,
            INodesInfoRequest
    {
        internal override ApiUrls ApiUrls => ApiUrlsLookups.NodesInfo;

        /// <summary>/_nodes</summary>
        public NodesInfoDescriptor()
            : base() { }

        /// <summary>/_nodes/{metric}</summary>
        /// <param name="metric">Optional, accepts null</param>
        public NodesInfoDescriptor(Metrics metric)
            : base(r => r.Optional("metric", metric)) { }

        /// <summary>/_nodes/{node_id}</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        public NodesInfoDescriptor(NodeIds nodeId)
            : base(r => r.Optional("node_id", nodeId)) { }

        /// <summary>/_nodes/{node_id}/{metric}</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        /// <param name="metric">Optional, accepts null</param>
        public NodesInfoDescriptor(NodeIds nodeId, Metrics metric)
            : base(r => r.Optional("node_id", nodeId).Optional("metric", metric)) { }

        // values part of the url path
        Metrics INodesInfoRequest.Metric => Self.RouteValues.Get<Metrics>("metric");
        NodeIds INodesInfoRequest.NodeId => Self.RouteValues.Get<NodeIds>("node_id");

        /// <summary>Limits the information returned to the specific metrics. Supports a comma-separated list, such as `http,ingest`.</summary>
        public NodesInfoDescriptor Metric(Metrics metric) =>
            Assign(metric, (a, v) => a.RouteValues.Optional("metric", v));

        /// <summary>Comma-separated list of node IDs or names used to limit returned information.</summary>
        public NodesInfoDescriptor NodeId(NodeIds nodeId) =>
            Assign(nodeId, (a, v) => a.RouteValues.Optional("node_id", v));

        // Request parameters
        /// <summary>If `true`, returns settings in flat format.</summary>
        public NodesInfoDescriptor FlatSettings(bool? flatsettings = true) =>
            Qs("flat_settings", flatsettings);

        /// <summary>Period to wait for a response. If no response is received before the timeout expires, the request fails and returns an error.</summary>
        public NodesInfoDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
    }

    /// <summary>Descriptor for ReloadSecureSettings <para>https://opensearch.org/docs/latest/api-reference/nodes-apis/nodes-reload-secure/</para></summary>
    public partial class ReloadSecureSettingsDescriptor
        : RequestDescriptorBase<
            ReloadSecureSettingsDescriptor,
            ReloadSecureSettingsRequestParameters,
            IReloadSecureSettingsRequest
        >,
            IReloadSecureSettingsRequest
    {
        internal override ApiUrls ApiUrls => ApiUrlsLookups.NodesReloadSecureSettings;

        /// <summary>/_nodes/reload_secure_settings</summary>
        public ReloadSecureSettingsDescriptor()
            : base() { }

        /// <summary>/_nodes/{node_id}/reload_secure_settings</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        public ReloadSecureSettingsDescriptor(NodeIds nodeId)
            : base(r => r.Optional("node_id", nodeId)) { }

        // values part of the url path
        NodeIds IReloadSecureSettingsRequest.NodeId => Self.RouteValues.Get<NodeIds>("node_id");

        /// <summary>The names of particular nodes in the cluster to target.</summary>
        public ReloadSecureSettingsDescriptor NodeId(NodeIds nodeId) =>
            Assign(nodeId, (a, v) => a.RouteValues.Optional("node_id", v));

        // Request parameters
        /// <summary>Period to wait for a response. If no response is received before the timeout expires, the request fails and returns an error.</summary>
        public ReloadSecureSettingsDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
    }

    /// <summary>Descriptor for Stats <para>https://opensearch.org/docs/latest/api-reference/nodes-apis/nodes-usage/</para></summary>
    public partial class NodesStatsDescriptor
        : RequestDescriptorBase<
            NodesStatsDescriptor,
            NodesStatsRequestParameters,
            INodesStatsRequest
        >,
            INodesStatsRequest
    {
        internal override ApiUrls ApiUrls => ApiUrlsLookups.NodesStats;

        /// <summary>/_nodes/stats</summary>
        public NodesStatsDescriptor()
            : base() { }

        /// <summary>/_nodes/stats/{metric}</summary>
        /// <param name="metric">Optional, accepts null</param>
        public NodesStatsDescriptor(Metrics metric)
            : base(r => r.Optional("metric", metric)) { }

        /// <summary>/_nodes/stats/{metric}/{index_metric}</summary>
        /// <param name="metric">Optional, accepts null</param>
        /// <param name="indexMetric">Optional, accepts null</param>
        public NodesStatsDescriptor(Metrics metric, IndexMetrics indexMetric)
            : base(r => r.Optional("metric", metric).Optional("index_metric", indexMetric)) { }

        /// <summary>/_nodes/{node_id}/stats</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        public NodesStatsDescriptor(NodeIds nodeId)
            : base(r => r.Optional("node_id", nodeId)) { }

        /// <summary>/_nodes/{node_id}/stats/{metric}</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        /// <param name="metric">Optional, accepts null</param>
        public NodesStatsDescriptor(NodeIds nodeId, Metrics metric)
            : base(r => r.Optional("node_id", nodeId).Optional("metric", metric)) { }

        /// <summary>/_nodes/{node_id}/stats/{metric}/{index_metric}</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        /// <param name="metric">Optional, accepts null</param>
        /// <param name="indexMetric">Optional, accepts null</param>
        public NodesStatsDescriptor(NodeIds nodeId, Metrics metric, IndexMetrics indexMetric)
            : base(r =>
                r.Optional("node_id", nodeId)
                    .Optional("metric", metric)
                    .Optional("index_metric", indexMetric)
            ) { }

        // values part of the url path
        IndexMetrics INodesStatsRequest.IndexMetric =>
            Self.RouteValues.Get<IndexMetrics>("index_metric");
        Metrics INodesStatsRequest.Metric => Self.RouteValues.Get<Metrics>("metric");
        NodeIds INodesStatsRequest.NodeId => Self.RouteValues.Get<NodeIds>("node_id");

        /// <summary>Limit the information returned for indexes metric to the specific index metrics. It can be used only if indexes (or all) metric is specified.</summary>
        public NodesStatsDescriptor IndexMetric(IndexMetrics indexMetric) =>
            Assign(indexMetric, (a, v) => a.RouteValues.Optional("index_metric", v));

        /// <summary>Limit the information returned to the specified metrics.</summary>
        public NodesStatsDescriptor Metric(Metrics metric) =>
            Assign(metric, (a, v) => a.RouteValues.Optional("metric", v));

        /// <summary>Comma-separated list of node IDs or names used to limit returned information.</summary>
        public NodesStatsDescriptor NodeId(NodeIds nodeId) =>
            Assign(nodeId, (a, v) => a.RouteValues.Optional("node_id", v));

        // Request parameters
        /// <summary>Comma-separated list or wildcard expressions of fields to include in field data and suggest statistics.</summary>
        public NodesStatsDescriptor CompletionFields(Fields completionfields) =>
            Qs("completion_fields", completionfields);

        /// <summary>Comma-separated list or wildcard expressions of fields to include in field data and suggest statistics.</summary>
        public NodesStatsDescriptor CompletionFields<T>(params Expression<Func<T, object>>[] fields)
            where T : class => Qs("completion_fields", fields?.Select(e => (Field)e));

        /// <summary>Comma-separated list or wildcard expressions of fields to include in field data statistics.</summary>
        public NodesStatsDescriptor FielddataFields(Fields fielddatafields) =>
            Qs("fielddata_fields", fielddatafields);

        /// <summary>Comma-separated list or wildcard expressions of fields to include in field data statistics.</summary>
        public NodesStatsDescriptor FielddataFields<T>(params Expression<Func<T, object>>[] fields)
            where T : class => Qs("fielddata_fields", fields?.Select(e => (Field)e));

        /// <summary>Comma-separated list or wildcard expressions of fields to include in the statistics.</summary>
        public NodesStatsDescriptor Fields(Fields fields) => Qs("fields", fields);

        /// <summary>Comma-separated list or wildcard expressions of fields to include in the statistics.</summary>
        public NodesStatsDescriptor Fields<T>(params Expression<Func<T, object>>[] fields)
            where T : class => Qs("fields", fields?.Select(e => (Field)e));

        /// <summary>Comma-separated list of search groups to include in the search statistics.</summary>
        public NodesStatsDescriptor Groups(params string[] groups) => Qs("groups", groups);

        /// <summary>If `true`, the call reports the aggregated disk usage of each one of the Lucene index files (only applies if segment stats are requested).</summary>
        public NodesStatsDescriptor IncludeSegmentFileSizes(bool? includesegmentfilesizes = true) =>
            Qs("include_segment_file_sizes", includesegmentfilesizes);

        /// <summary>Indicates whether statistics are aggregated at the cluster, index, or shard level.</summary>
        public NodesStatsDescriptor Level(Level? level) => Qs("level", level);

        /// <summary>Period to wait for a response. If no response is received before the timeout expires, the request fails and returns an error.</summary>
        public NodesStatsDescriptor Timeout(Time timeout) => Qs("timeout", timeout);

        /// <summary>A comma-separated list of document types for the indexing index metric.</summary>
        public NodesStatsDescriptor Types(params string[] types) => Qs("types", types);
    }

    /// <summary>Descriptor for Usage <para>https://opensearch.org/docs/latest</para></summary>
    public partial class NodesUsageDescriptor
        : RequestDescriptorBase<
            NodesUsageDescriptor,
            NodesUsageRequestParameters,
            INodesUsageRequest
        >,
            INodesUsageRequest
    {
        internal override ApiUrls ApiUrls => ApiUrlsLookups.NodesUsage;

        /// <summary>/_nodes/usage</summary>
        public NodesUsageDescriptor()
            : base() { }

        /// <summary>/_nodes/usage/{metric}</summary>
        /// <param name="metric">Optional, accepts null</param>
        public NodesUsageDescriptor(Metrics metric)
            : base(r => r.Optional("metric", metric)) { }

        /// <summary>/_nodes/{node_id}/usage</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        public NodesUsageDescriptor(NodeIds nodeId)
            : base(r => r.Optional("node_id", nodeId)) { }

        /// <summary>/_nodes/{node_id}/usage/{metric}</summary>
        /// <param name="nodeId">Optional, accepts null</param>
        /// <param name="metric">Optional, accepts null</param>
        public NodesUsageDescriptor(NodeIds nodeId, Metrics metric)
            : base(r => r.Optional("node_id", nodeId).Optional("metric", metric)) { }

        // values part of the url path
        Metrics INodesUsageRequest.Metric => Self.RouteValues.Get<Metrics>("metric");
        NodeIds INodesUsageRequest.NodeId => Self.RouteValues.Get<NodeIds>("node_id");

        /// <summary>Limits the information returned to the specific metrics. A comma-separated list of the following options: `_all`, `rest_actions`.</summary>
        public NodesUsageDescriptor Metric(Metrics metric) =>
            Assign(metric, (a, v) => a.RouteValues.Optional("metric", v));

        /// <summary>A comma-separated list of node IDs or names to limit the returned information; use `_local` to return information from the node you're connecting to, leave empty to get information from all nodes.</summary>
        public NodesUsageDescriptor NodeId(NodeIds nodeId) =>
            Assign(nodeId, (a, v) => a.RouteValues.Optional("node_id", v));

        // Request parameters
        /// <summary>Period to wait for a response. If no response is received before the timeout expires, the request fails and returns an error.</summary>
        public NodesUsageDescriptor Timeout(Time timeout) => Qs("timeout", timeout);
    }
}
