﻿using System.Threading.Tasks;
using PsawSharp.Entries;
using PsawSharp.Requests;
using PsawSharp.Requests.Options;

namespace PsawSharp
{
    public class PsawClient
    {

        #region Fields
        
        private readonly RequestsManager _requestsManager;

        #endregion

        public PsawClient()
        {
            _requestsManager = new RequestsManager();
        }

        public PsawClient(RequestsManagerOptions options)
        {
            _requestsManager = new RequestsManager(options);
        }

        #region Public Methods

        public async Task<T[]> Search<T>(SearchOptions options = null) where T : IEntry
        {
            string type = typeof(T).Name.Replace("Entry", "").ToLower();
            string route = string.Format(RequestsConstants.SearchRoute, type);
            var result = await _requestsManager.PerformGet(route, options?.ToArgs());
            return result["data"].ToObject<T[]>();
        }

        public async Task<string[]> GetSubmissionCommentIds(string base36SubmissionId)
        {
            string route = string.Format(RequestsConstants.CommentIdsRoute, base36SubmissionId);
            var result = await _requestsManager.PerformGet(route);
            return result["data"].ToObject<string[]>();
        }

        public async Task<MetaEntry> GetMeta()
        {
            var result = await _requestsManager.PerformGet("meta");
            return result.ToObject<MetaEntry>();
        }

        #endregion

    }
}
