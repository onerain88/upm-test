using System;
using System.Collections.Generic;
using TapTap.Common;
using UnityEngine;



namespace TapTap.Billboard
{
    public class OpenPanelResultWrapper
    {
        public bool openResult;

        public TapError error;

        public OpenPanelResultWrapper(string json)
        {
            var dic = Json.Deserialize(json) as Dictionary<string, object>;
            var errorJson = SafeDictionary.GetValue<string>(dic, "error");
            if (!string.IsNullOrEmpty(errorJson))
            {
                error = new TapError(errorJson);
            }
            if (dic != null && dic.ContainsKey("openResult"))
            {
                openResult =  SafeDictionary.GetValue<bool>(dic, "openResult");
            }
        }
    }
}