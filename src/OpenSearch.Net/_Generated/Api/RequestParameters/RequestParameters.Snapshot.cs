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
namespace OpenSearch.Net.Specification.SnapshotApi
{
    /// <summary>Request options for CleanupRepository <para>https://opensearch.org/docs/latest</para></summary>
    public partial class CleanupRepositoryRequestParameters
        : RequestParameters<CleanupRepositoryRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
        public override bool SupportsBody => false;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Period to wait for a connection to the cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }

        /// <summary>The amount of time to wait for a response.</summary>
        public TimeSpan Timeout
        {
            get => Q<TimeSpan>("timeout");
            set => Q("timeout", value);
        }
    }

    /// <summary>Request options for Clone <para>https://opensearch.org/docs/latest</para></summary>
    public partial class CloneSnapshotRequestParameters
        : RequestParameters<CloneSnapshotRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
        public override bool SupportsBody => true;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }
    }

    /// <summary>Request options for Snapshot <para>https://opensearch.org/docs/latest/api-reference/snapshots/create-snapshot/</para></summary>
    public partial class SnapshotRequestParameters : RequestParameters<SnapshotRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
        public override bool SupportsBody => true;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>
        /// Period to wait for a connection to the cluster-manager node. If no response is received before the timeout expires, the request fails and
        /// returns an error.
        /// </summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }

        /// <summary>
        /// When `true`, the request returns a response when the snapshot is complete. When `false`, the request returns a response when the snapshot
        /// initializes.
        /// </summary>
        public bool? WaitForCompletion
        {
            get => Q<bool?>("wait_for_completion");
            set => Q("wait_for_completion", value);
        }
    }

    /// <summary>Request options for CreateRepository <para>https://opensearch.org/docs/latest/api-reference/snapshots/create-repository/</para></summary>
    public partial class CreateRepositoryRequestParameters
        : RequestParameters<CreateRepositoryRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.PUT;
        public override bool SupportsBody => true;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }

        /// <summary>The amount of time to wait for a response.</summary>
        public TimeSpan Timeout
        {
            get => Q<TimeSpan>("timeout");
            set => Q("timeout", value);
        }

        /// <summary>When `true`, verifies the creation of the snapshot repository.</summary>
        public bool? Verify
        {
            get => Q<bool?>("verify");
            set => Q("verify", value);
        }
    }

    /// <summary>Request options for Delete <para>https://opensearch.org/docs/latest/api-reference/snapshots/delete-snapshot/</para></summary>
    public partial class DeleteSnapshotRequestParameters
        : RequestParameters<DeleteSnapshotRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
        public override bool SupportsBody => false;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }
    }

    /// <summary>Request options for DeleteRepository <para>https://opensearch.org/docs/latest/api-reference/snapshots/delete-snapshot-repository/</para></summary>
    public partial class DeleteRepositoryRequestParameters
        : RequestParameters<DeleteRepositoryRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
        public override bool SupportsBody => false;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }

        /// <summary>The amount of time to wait for a response.</summary>
        public TimeSpan Timeout
        {
            get => Q<TimeSpan>("timeout");
            set => Q("timeout", value);
        }
    }

    /// <summary>Request options for Get <para>https://opensearch.org/docs/latest</para></summary>
    public partial class GetSnapshotRequestParameters
        : RequestParameters<GetSnapshotRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
        public override bool SupportsBody => false;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>When `false`, the request returns an error for any snapshots that are unavailable.</summary>
        public bool? IgnoreUnavailable
        {
            get => Q<bool?>("ignore_unavailable");
            set => Q("ignore_unavailable", value);
        }

        /// <summary>
        /// Period to wait for a connection to the cluster-manager node. If no response is received before the timeout expires, the request fails and
        /// returns an error.
        /// </summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }

        /// <summary>
        /// When `true`, returns additional information about each snapshot such as the version of OpenSearch which took the snapshot, the start and
        /// end times of the snapshot, and the number of shards contained in the snapshot.
        /// </summary>
        public bool? Verbose
        {
            get => Q<bool?>("verbose");
            set => Q("verbose", value);
        }
    }

    /// <summary>Request options for GetRepository <para>https://opensearch.org/docs/latest/api-reference/snapshots/get-snapshot-repository/</para></summary>
    public partial class GetRepositoryRequestParameters
        : RequestParameters<GetRepositoryRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
        public override bool SupportsBody => false;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Whether to get information from the local node.</summary>
        public bool? Local
        {
            get => Q<bool?>("local");
            set => Q("local", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }
    }

    /// <summary>Request options for Restore <para>https://opensearch.org/docs/latest/api-reference/snapshots/restore-snapshot/</para></summary>
    public partial class RestoreRequestParameters : RequestParameters<RestoreRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
        public override bool SupportsBody => true;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }

        /// <summary>
        /// -| Whether to return a response after the restore operation has completed. When `false`, the request returns a response when the restore
        /// operation initializes. When `true`, the request returns a response when the restore operation completes.
        /// </summary>
        public bool? WaitForCompletion
        {
            get => Q<bool?>("wait_for_completion");
            set => Q("wait_for_completion", value);
        }
    }

    /// <summary>Request options for Status <para>https://opensearch.org/docs/latest/api-reference/snapshots/get-snapshot-status/</para></summary>
    public partial class SnapshotStatusRequestParameters
        : RequestParameters<SnapshotStatusRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
        public override bool SupportsBody => false;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Whether to ignore any unavailable snapshots, When `false`, a `SnapshotMissingException` is thrown.</summary>
        public bool? IgnoreUnavailable
        {
            get => Q<bool?>("ignore_unavailable");
            set => Q("ignore_unavailable", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }
    }

    /// <summary>Request options for VerifyRepository <para>https://opensearch.org/docs/latest/api-reference/snapshots/verify-snapshot-repository/</para></summary>
    public partial class VerifyRepositoryRequestParameters
        : RequestParameters<VerifyRepositoryRequestParameters>
    {
        public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
        public override bool SupportsBody => false;

        /// <summary>
        /// The amount of time to wait for a response from the cluster manager node. For more information about supported time units, see [Common
        /// parameters](https://opensearch.org/docs/latest/api-reference/common-parameters/#time-units).
        /// </summary>
        /// <remarks>Supported by OpenSearch servers of version 2.0.0 or greater.</remarks>
        public TimeSpan ClusterManagerTimeout
        {
            get => Q<TimeSpan>("cluster_manager_timeout");
            set => Q("cluster_manager_timeout", value);
        }

        /// <summary>Explicit operation timeout for connection to cluster-manager node.</summary>
        [Obsolete(
            "Deprecated as of: 2.0.0, reason: To promote inclusive language, use `cluster_manager_timeout` instead."
        )]
        public TimeSpan MasterTimeout
        {
            get => Q<TimeSpan>("master_timeout");
            set => Q("master_timeout", value);
        }

        /// <summary>The amount of time to wait for a response.</summary>
        public TimeSpan Timeout
        {
            get => Q<TimeSpan>("timeout");
            set => Q("timeout", value);
        }
    }
}
