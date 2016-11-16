﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Elasticsearch.Net
{
	public class SniffResponse
	{
		//internal ctor  - so that only Elasticsearch.Net can instantiate it
		internal SniffResponse() { }

		public static Regex AddressRegex { get; } = new Regex(@"^((?<fqdn>[^/]+)/)?(?<ip>[^:]+|\[[\da-fA-F:\.]+\]):(?<port>\d+)$");

		public string cluster_name { get; set; }

		public Dictionary<string, NodeInfo> nodes { get; set; }

		public IEnumerable<Node> ToNodes(bool forceHttp = false)
		{
			foreach (var kv in nodes.Where(n => n.Value.HttpEnabled))
			{
				yield return new Node(this.ParseToUri(kv.Value.http?.bound_address.FirstOrDefault(), forceHttp))
				{
					Name = kv.Value.name,
					Id = kv.Key,
					MasterEligible = kv.Value.MasterEligible,
					HoldsData = kv.Value.HoldsData,
					HttpEnabled = kv.Value.HttpEnabled
				};
			}
		}

		private Uri ParseToUri(string boundAddress, bool forceHttp)
		{
			if (boundAddress.IsNullOrEmpty()) return null;
			var suffix = forceHttp ? "s" : string.Empty;
			var match = AddressRegex.Match(boundAddress);
			if (!match.Success) throw new Exception($"Can not parse bound_address: {boundAddress} to Uri");

			var fqdn = match.Groups["fqdn"].Value?.Trim();
			var ip = match.Groups["ip"].Value?.Trim();
			var port = match.Groups["port"].Value?.Trim();
			var host = !fqdn.IsNullOrEmpty() ? fqdn : ip;

			return new Uri($"http{suffix}://{host}:{port}");
		}
	}

	public class NodeInfo
	{
		public string name { get; set; }
		public string transport_address { get; set; }
		public string host { get; set; }
		public string ip { get; set; }
		public string version { get; set; }
		public string build_hash { get; set; }
		public IList<string> roles { get; set; }
		public NodeInfoHttp http { get; set; }
		public IDictionary<string, string> settings { get; set; }

		internal bool MasterEligible => this.roles?.Contains("master") ?? false;
		internal bool HoldsData => this.roles?.Contains("data") ?? false;
		internal bool HttpEnabled
		{
			get
			{
				if (this.settings != null && this.settings.ContainsKey("http.enabled"))
					return Convert.ToBoolean(this.settings["http.enabled"]);
				return http != null;
			}
		}
	}

	public class NodeInfoHttp
	{
		public IList<string> bound_address { get; set; }
	}
}
