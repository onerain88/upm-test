using System.Collections.Generic;
using TapTap.Common;

namespace TapTap.Billboard
{
    public class BadgeDetails
    {
        public string closeButtonImg;

        public int showRedDot;

        public BadgeDetails(string json)
        {
            var dic = Json.Deserialize(json) as Dictionary<string, object>;
            closeButtonImg = SafeDictionary.GetValue<string>(dic, "closeButtonImg");
            showRedDot = SafeDictionary.GetValue<int>(dic, "showRedDot");
        }

        public BadgeDetails(Dictionary<string, object> dic)
        {
            closeButtonImg = SafeDictionary.GetValue<string>(dic, "closeButtonImg");
            showRedDot = SafeDictionary.GetValue<int>(dic, "showRedDot");
        }

        public string ToJson()
        {
            var dic = new Dictionary<string, object>
            {
                ["closeButtonImg"] = closeButtonImg,
                ["showRedDot"] = showRedDot
            };
            return Json.Serialize(dic);
        }
    }
}