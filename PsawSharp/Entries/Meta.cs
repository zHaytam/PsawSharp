using Newtonsoft.Json;

namespace PsawSharp.Entries
{
    public class Meta
    {

        [JsonProperty("client_accepts_json")]
        public bool ClientAcceptsJson { get; set; }

        [JsonProperty("client_request_headers")]
        public ClientRequestHeaders ClientRequestHeaders { get; set; }

        [JsonProperty("client_user_agent")]
        public string ClientUserAgent { get; set; }

        [JsonProperty("server_ratelimit_per_minute")]
        public int ServerRatelimitPerMinute { get; set; }

        [JsonProperty("sourceip")]
        public string Sourceip { get; set; }

    }

    public class ClientRequestHeaders
    {

        [JsonProperty("ACCEPT")]
        public string Accept { get; set; }

        [JsonProperty("ACCEPTENCODING")]
        public string AcceptEncoding { get; set; }

        [JsonProperty("ACCEPTLANGUAGE")]
        public string AcceptLanguage { get; set; }

        [JsonProperty("CACHECONTROL")]
        public string CacheControl { get; set; }

        [JsonProperty("CFCONNECTINGIP")]
        public string CfConnectingIp { get; set; }

        [JsonProperty("CFIPCOUNTRY")]
        public string CfIpCountry { get; set; }

        [JsonProperty("CFRAY")]
        public string Cfray { get; set; }

        [JsonProperty("CFVISITOR")]
        public string CfVisitor { get; set; }

        [JsonProperty("CONNECTION")]
        public string Connection { get; set; }

        [JsonProperty("COOKIE")]
        public string Cookie { get; set; }

        [JsonProperty("HOST")]
        public string Host { get; set; }

        [JsonProperty("UPGRADEINSECUREREQUESTS")]
        public string UpgradeInsecureRequests { get; set; }

        [JsonProperty("USERAGENT")]
        public string Useragent { get; set; }

        [JsonProperty("XFORWARDEDFOR")]
        public string XForwardedFor { get; set; }

        [JsonProperty("XFORWARDEDPROTO")]
        public string XForwardedProto { get; set; }

    }
}
