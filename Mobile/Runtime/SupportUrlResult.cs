#if UNITY_ANDROID || UNITY_IOS

using LC.Newtonsoft.Json;

namespace TapTap.Support.Internal.Platform {
    public class SupportUrlResult {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

#endif