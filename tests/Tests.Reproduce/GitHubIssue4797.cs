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
* 	http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing,
*  software distributed under the License is distributed on an
*  "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
*  KIND, either express or implied.  See the License for the
*  specific language governing permissions and limitations
*  under the License.
*/

using System.Text;
using OpenSearch.OpenSearch.Xunit.XunitPlumbing;
using FluentAssertions;
using OpenSearch.Client;
using OpenSearch.Net;
using Tests.Core.Client;

namespace Tests.Reproduce
{
	public class GitHubIssue4797
	{
		[U]
		public void DeserializeSortWithOnlyFieldAndOrder()
		{
			var json = @"
			{
			    ""sort"" : [
			        { ""post_date"" : {""order"" : ""asc""}},
			        ""user"",
			        { ""name"" : ""desc"" },
			        { ""age"" : ""desc"" },
			        ""_score""
			    ],
			    ""query"" : {
			        ""term"" : { ""user"" : ""kimchy"" }
			    }
			}
			";

			var bytes = Encoding.UTF8.GetBytes(json);
			var client = TestClient.FixedInMemoryClient(bytes);

			using var stream = client.ConnectionSettings.MemoryStreamFactory.Create(bytes);
			var request = client.RequestResponseSerializer.Deserialize<SearchRequest>(stream);

			request.Should().NotBeNull();
			request.Sort.Should().NotBeNull().And.HaveCount(5);
			request.Sort[1].SortKey.Should().Be("user");
			request.Sort[2].SortKey.Should().Be("name");
			request.Sort[2].Order.Should().Be(SortOrder.Descending);
		}
	}
}
