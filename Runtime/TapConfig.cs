using System.Collections.Generic;
using TapTap.Common;
using System.Linq;

namespace TapTap.Common
{
    public class TapConfig
    {
        public readonly string ClientID;

        public readonly string ClientToken;

        public readonly RegionType RegionType;

        public readonly string ServerURL;

        public readonly TapDBConfig DBConfig;

        public readonly TapPaymentConfig PaymentConfig;

        /// <summary>
        /// PC 论坛 id
        /// </summary>
        public readonly string AppID;
        public readonly TapBillboardConfig BillboardConfig;

        private TapConfig(string clientID, string clientToken, RegionType regionType, string serverUrl)
        {
            ClientID = clientID;
            ClientToken = clientToken;
            RegionType = regionType;
            ServerURL = serverUrl;
        }

        private TapConfig(string clientID, string clientToken, RegionType regionType, string serverUrl,
            bool enableTapDB, string channel,
            string gameVersion)
            : this(clientID, clientToken, regionType, serverUrl)
        {
            DBConfig = new TapDBConfig(enableTapDB, channel, gameVersion);
        }

        private TapConfig(string clientID, string clientToken, RegionType regionType, string serverUrl,
            bool enableTapDB, string channel,
            string gameVersion, bool advertiserIDCollectionEnabled)
            : this(clientID, clientToken, regionType, serverUrl)
        {
            DBConfig = new TapDBConfig(enableTapDB, channel, gameVersion, advertiserIDCollectionEnabled);
        }

        private TapConfig(string clientID, string clientToken, RegionType regionType, string serverUrl,
           bool enableTapDB, string channel,
           string gameVersion, bool advertiserIDCollectionEnabled, Dictionary<string,object> properties)
        {
            ClientID = clientID;
            ClientToken = clientToken;
            ServerURL = serverUrl;
            RegionType = regionType;
            DBConfig = new TapDBConfig(enableTapDB, channel, gameVersion, advertiserIDCollectionEnabled, properties);
        }

        private TapConfig(string clientID, string clientToken, RegionType regionType, string serverUrl,
            bool enableTapDB, string channel,
            string gameVersion, bool advertiserIDCollectionEnabled,
            string regionId, string language, string wxAuthorizedDomainName)
            : this(clientID, clientToken, regionType, serverUrl, enableTapDB, channel, gameVersion, advertiserIDCollectionEnabled)
        {
            PaymentConfig = new TapPaymentConfig(regionId, language, wxAuthorizedDomainName);
        }

        private TapConfig(string clientID, string clientToken, RegionType regionType, string serverUrl,
            bool enableTapDB, string channel,
            string gameVersion, bool advertiserIDCollectionEnabled, Dictionary<string,object> properties,
            string regionId, string language, string wxAuthorizedDomainName,
            string appId,
            HashSet<KeyValuePair<string, string>> dimensionSet, string template, string billboardServerUrl
            )
        {
            ClientID = clientID;
            ClientToken = clientToken;
            ServerURL = serverUrl;
            RegionType = regionType;
            DBConfig = new TapDBConfig(enableTapDB, channel, gameVersion, advertiserIDCollectionEnabled, properties);
            PaymentConfig = new TapPaymentConfig(regionId, language, wxAuthorizedDomainName);
            AppID = appId;
            BillboardConfig = new TapBillboardConfig(dimensionSet, template, billboardServerUrl);
        }
        
        public string ToJson()
        {
            var dic = new Dictionary<string, object>
            {
                ["clientID"] = ClientID,
                ["clientToken"] = ClientToken,
                ["isCN"] = RegionType == RegionType.CN,
                ["dbConfig"] = DBConfig?.ToDic(),
                ["paymentConfig"] = PaymentConfig?.toDic(),
                ["appID"] = AppID,
                ["billboardConfig"] = BillboardConfig?.toDic()
            };

            return Json.Serialize(dic);
        }
 
        public class Builder
        {
            private string _clientID;

            private string _clientToken;

            private string _serverURL;

            private RegionType _regionType;

            private bool _enableTapDB = true;


            private string _channel;

            private string _gameVersion;

            private bool _advertiserIDCollectionEnabled;

            private Dictionary<string, object> _deviceLoginProperties;

            private string _paymentRegionId;

            private string _paymentLanguage;

            private string _wxAuthorizedDomainName;

            private string _appId;
            private HashSet<KeyValuePair<string, string>> _dimensionSet;

            private string _template;

            private string _billboardServerUrl;

            public Builder()
            {
            }

            public Builder ClientID(string clientId)
            {
                _clientID = clientId;
                return this;
            }

            public Builder ClientToken(string secret)
            {
                _clientToken = secret;
                return this;
            }

            public Builder ServerURL(string serverURL)
            {
                _serverURL = serverURL;
                return this;
            }

            public Builder RegionType(RegionType type)
            {
                _regionType = type;
                return this;
            }

            public Builder EnableTapDB(bool enable)
            {
                _enableTapDB = enable;
                return this;
            }

            public Builder AppId(string appId) {
                _appId = appId;
                return this;
            }

            public Builder TapDBConfig(bool enable, string channel, string gameVersion)
            {
                _enableTapDB = enable;
                _channel = channel;
                _gameVersion = gameVersion;
                return this;
            }

            public Builder TapDBConfig(bool enable, string channel, string gameVersion,
                bool advertiserIDCollectionEnabled)
            {
                _enableTapDB = enable;
                _channel = channel;
                _gameVersion = gameVersion;
                _advertiserIDCollectionEnabled = advertiserIDCollectionEnabled;
                return this;
            }

            public Builder TapDBConfig(bool enable, string channel, string gameVersion,
                bool advertiserIDCollectionEnabled, Dictionary<string,object> properties)
            {
                _enableTapDB = enable;
                _channel = channel;
                _gameVersion = gameVersion;
                _advertiserIDCollectionEnabled = advertiserIDCollectionEnabled;
                _deviceLoginProperties = properties;
                return this;
            }

            public Builder TapPaymentConfig(string regionId, string language, string wxAuthorizedDomainName)
            {
                _paymentRegionId = regionId;
                _paymentLanguage = language;
                _wxAuthorizedDomainName = wxAuthorizedDomainName;
                return this;
            }
            
            public Builder TapBillboardConfig(HashSet<KeyValuePair<string, string>> dimensionSet, string template, string billboardServerUrl)
            {
                _dimensionSet = dimensionSet;
                _template = template;
                _billboardServerUrl = billboardServerUrl;
                return this;
            }

            public TapConfig ConfigBuilder()
            {
                return new TapConfig(_clientID, _clientToken, _regionType, _serverURL, _enableTapDB, _channel,
                    _gameVersion,
                    _advertiserIDCollectionEnabled,
                    _deviceLoginProperties,
                    _paymentRegionId,
                    _paymentLanguage,
                    _wxAuthorizedDomainName,
                    _appId,
                    _dimensionSet,
                    _template,
                    _billboardServerUrl
                    );
            }
        }
    }


    public class TapDBConfig
    {
        public readonly bool Enable;

        public readonly string Channel;

        public readonly string GameVersion;

        public readonly bool AdvertiserIDCollectionEnabled;

        public readonly Dictionary<string, object> DeviceLoginProperties;

        public TapDBConfig(bool enable)
        {
            Enable = enable;
        }

        public TapDBConfig(bool enable, string channel, string gameVersion)
        {
            Enable = enable;
            Channel = channel;
            GameVersion = gameVersion;
        }

        public TapDBConfig(bool enable, string channel, string gameVersion, bool advertiserIDCollectionEnabled)
        {
            Enable = enable;
            Channel = channel;
            GameVersion = gameVersion;
            AdvertiserIDCollectionEnabled = advertiserIDCollectionEnabled;
        }

        public TapDBConfig(bool enable, string channel, string gameVersion, bool advertiserIDCollectionEnabled, Dictionary<string,object> properities)
        {
            Enable = enable;
            Channel = channel;
            GameVersion = gameVersion;
            AdvertiserIDCollectionEnabled = advertiserIDCollectionEnabled;
            DeviceLoginProperties = properities;
        }

        public Dictionary<string, object> ToDic()
        {
            return new Dictionary<string, object>
            {
                ["channel"] = Channel,
                ["gameVersion"] = GameVersion,
                ["enable"] = Enable,
                ["advertiserIDCollectionEnabled"] = AdvertiserIDCollectionEnabled,
                ["deviceLoginProperties"] = DeviceLoginProperties
            };
        }
    }

    public class TapPaymentConfig
    {
        public readonly string RegionId;

        public readonly string Language;

        public readonly string WXAuthorizedDomainName;

        public TapPaymentConfig(string regionId, string language, string wxAuthorizedDomainName) {
            RegionId = regionId;
            Language = language;
            WXAuthorizedDomainName = wxAuthorizedDomainName;
        }

        public Dictionary<string, object> toDic()
        {
            return new Dictionary<string, object>
            {
                ["regionId"] = RegionId,
                ["language"] = Language,
                ["wxAuthorizedDomainName"] = WXAuthorizedDomainName
            };
        }
    }

    public class TapBillboardConfig
    {
        public readonly HashSet<KeyValuePair<string, string>> DimensionSet;

        public readonly string Template;

        public readonly string ServerUrl;

        public TapBillboardConfig(HashSet<KeyValuePair<string, string>> dimensionSet, string template, string serverUrl) {
            DimensionSet = dimensionSet;
            Template = template;
            ServerUrl = serverUrl;
        }

        public Dictionary<string, object> toDic() {    
            List<List<string>> result = new List<List<string>>();
            if (DimensionSet != null) {
                List<KeyValuePair<string, string>> dimensionList = DimensionSet.ToList();
                dimensionList.ForEach(pair =>
                {
                    if (pair.Key != null && pair.Key.Length > 0
                    && pair.Value != null && pair.Value.Length > 0)
                    {
                        List<string> item = new List<string>();
                        item.Add(pair.Key);
                        item.Add(pair.Value);
                        result.Add(item);
                    }
                });       
            }

            return new Dictionary<string, object>
            {
                ["dimensionSet"] = result,
                ["template"] = Template,
                ["serverUrl"] = ServerUrl
            };
        }
    }
}
