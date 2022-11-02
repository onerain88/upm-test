#if UNITY_STANDALONE || UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;
using LC.Newtonsoft.Json;
using TapTap.Common.Internal.Http;

namespace TapTap.Support.Internal.Platform {
    public class TapSupportStandalone : ITapSupport {
        private static readonly string UNREAD_ENDPOINT = "/api/2/unread";
        private const int POLL_INTERVAL = 10;

        private string serverUrl;
        private string rootCategoryId;
        private TapSupportDelegate supportDelegate;
        private Dictionary<string, object> defaultMetaData;
        private Dictionary<string, object> defaultFieldsData;
        private string anonymousUserId;

        private TapSupportPoll poll;
        private Coroutine pollCoroutine;

        private HttpClient httpClient;

        private HttpClient HttpClient {
            get {
                if (httpClient == null) {
                    httpClient = new HttpClient();
                }
                return httpClient;
            }
        }

        public void Init(string serverUrl, string rootCategoryId, TapSupportDelegate supportDelegate) {
            this.serverUrl = serverUrl;
            this.rootCategoryId = rootCategoryId;
            this.supportDelegate = supportDelegate;
        }

        public void SetDefaultMetaData(Dictionary<string, object> metaData) {
            defaultMetaData = metaData;
        }

        public void SetDefaultFieldsData(Dictionary<string, object> fieldsData) {
            defaultFieldsData = fieldsData;
        }

        public void LoginAnonymously(string userId) {
            anonymousUserId = userId;
        }

        public Task<string> GetSupportWebUrl(string path = null, Dictionary<string, object> metaData = null, Dictionary<string, object> fieldsData = null) {
            if (string.IsNullOrEmpty(path)) {
                path = "/";
            }

            string url = $"{serverUrl}/in-app/v1/categories/{rootCategoryId}{path}#anonymous-id={anonymousUserId}";

            if (metaData == null) {
                metaData = defaultMetaData;
            }
            string metaStr = GetEncodeData(metaData);
            if (!string.IsNullOrEmpty(metaStr)) {
                url = $"{url}&meta={metaStr}";
            }

            if (fieldsData == null) {
                fieldsData = defaultFieldsData;
            }
            string fieldStr = GetEncodeData(fieldsData);
            if (!string.IsNullOrEmpty(fieldStr)) {
                url = $"{url}&fields={fieldStr}";
            }

            return Task.FromResult(url);
        }

        public async void OpenSupportView(string path = null, Dictionary<string, object> metaData = null, Dictionary<string, object> fieldsData = null) {
            string url = await GetSupportWebUrl(path, metaData, fieldsData);
            Application.OpenURL(url);
        }

        public void CloseSupportView() {
            throw new NotImplementedException();
        }

        public void Resume() {
            if (poll == null) {
                GameObject pollGo = new GameObject("_TapSupportPoll");
                poll = pollGo.AddComponent<TapSupportPoll>();
                UnityEngine.Object.DontDestroyOnLoad(pollGo);
            }
            if (pollCoroutine == null) {
                pollCoroutine = poll.StartCoroutine(Poll());
            }
        }

        private IEnumerator Poll() {
            while (true) {
                FetchUnReadStatus();
                yield return new WaitForSeconds(POLL_INTERVAL);
            }
        }

        public void Pause() {
            if (pollCoroutine != null) {
                poll.StopCoroutine(pollCoroutine);
                pollCoroutine = null;
            }
        }

        public async void FetchUnReadStatus() {
            try {
                HttpRequestMessage request = new HttpRequestMessage {
                    RequestUri = new Uri($"{serverUrl}{UNREAD_ENDPOINT}"),
                    Method = HttpMethod.Get,
                };
                request.Headers.Add("X-Anonymous-ID", anonymousUserId);
                TapHttpUtils.PrintRequest(HttpClient, request);

                HttpResponseMessage response = await HttpClient.SendAsync(request);
                request.Dispose();

                string resultString = await response.Content.ReadAsStringAsync();
                response.Dispose();
                TapHttpUtils.PrintResponse(response, resultString);

                bool hasUnread = "true".Equals(resultString);
                supportDelegate?.OnUnreadStatusChanged?.Invoke(hasUnread);
            } catch (Exception e) {
                supportDelegate?.OnGetUnreadStatusError?.Invoke(e);
            }
        }

        private static string GetEncodeData(Dictionary<string, object> data) {
            if (data == null) {
                return null;
            }
            return Uri.EscapeDataString(JsonConvert.SerializeObject(data));
        }
    }
}

#endif
