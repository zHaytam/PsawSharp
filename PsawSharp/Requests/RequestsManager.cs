using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PsawSharp.Requests.Options;

namespace PsawSharp.Requests
{
    public class RequestsManager
    {

        #region Fields

        private readonly RequestsManagerOptions _options;
        private HttpClient _httpClient;

        #endregion

        public RequestsManager()
        {
            _options = new RequestsManagerOptions();
            InitializeHttpClient();
        }

        public RequestsManager(RequestsManagerOptions options)
        {
            _options = options;
            InitializeHttpClient();
        }

        #region Internal Methods

        internal async Task<JToken> ExecuteGet(string route, List<string> args = null)
        {
            // Execute request and ensure it didn't fail
            var response = await _httpClient.GetAsync(ConstructUrl(route, args));
            response.EnsureSuccessStatusCode();

            // Convert response to json
            string result = await response.Content.ReadAsStringAsync();
            return JToken.Parse(result);
        }

        #endregion

        #region Private Methods

        private string ConstructUrl(string route, List<string> args) => args == null ? route : $"{route}?{ArgsToString(args)}";

        private static string ArgsToString(List<string> args) => args.Aggregate((x, y) => $"{x}&{y}");

        private void InitializeHttpClient()
        {
            if (_options.UseProxy)
            {
                _httpClient = new HttpClient(new HttpClientHandler
                {
                    UseProxy = true,
                    Proxy = new WebProxy(_options.ProxyAddress)
                });
            }
            else
            {
                _httpClient = new HttpClient();
            }

            _httpClient.BaseAddress = new Uri(RequestsConstants.BaseAddress);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", _options.UserAgent);
        }

        #endregion

    }
}
