using System.Collections.Generic;
using TapTap.Common;
using UnityEngine;

namespace TapTap.Achievement
{
    public class TapAchievementBean
    {
        public static readonly int StateUnReached = 0;

        public static readonly int StateReached = 1;

        public static readonly int VisibleFalse = 0;

        public static readonly int VisibleTrue = 1;

        /*base*/
        public string id;

        public string displayId;

        public int visible = VisibleFalse;

        public string title;

        public string subTitle;

        public string achieveIcon;

        public int step;

        public long createTime;

        public int showOrder;

        /*user*/
        public bool fullReached;

        public int reachedStep;

        public long reachedTime;

        public bool isChanged;

        public int type;

        public AchievementStats stats;

        public TapAchievementBean(string json)
        {
            var dic = Json.Deserialize(json) as Dictionary<string, object>;
            id = SafeDictionary.GetValue<string>(dic, "id");
            displayId = SafeDictionary.GetValue<string>(dic, "displayId");
            visible = SafeDictionary.GetValue<int>(dic, "visible");
            title = SafeDictionary.GetValue<string>(dic, "title");
            subTitle = SafeDictionary.GetValue<string>(dic, "subTitle");
            achieveIcon = SafeDictionary.GetValue<string>(dic, "achieveIcon");
            step = SafeDictionary.GetValue<int>(dic, "step");
            createTime = SafeDictionary.GetValue<long>(dic, "createTime");
            showOrder = SafeDictionary.GetValue<int>(dic, "showOrder");
            fullReached = SafeDictionary.GetValue<bool>(dic, "fullReached");
            reachedStep = SafeDictionary.GetValue<int>(dic, "reachedStep");
            reachedTime = SafeDictionary.GetValue<long>(dic, "reachedTime");
            isChanged = SafeDictionary.GetValue<bool>(dic, "isChanged");
            type = SafeDictionary.GetValue<int>(dic, "type");
            if (Platform.IsIOS())
            {
                Debug.Log($"AchievementStats:{SafeDictionary.GetValue<string>(dic, "stats")}");
                stats = new AchievementStats(SafeDictionary.GetValue<string>(dic, "stats"));
            }
            else if (Platform.IsAndroid())
            {
                if (SafeDictionary.GetValue<Dictionary<string, object>>(dic, "stats") is Dictionary<string, object>
                    statsDic)
                {
                    stats = new AchievementStats(statsDic);
                }
            }
        }

        public TapAchievementBean(Dictionary<string, object> dic)
        {
            id = SafeDictionary.GetValue<string>(dic, "id");
            displayId = SafeDictionary.GetValue<string>(dic, "displayId");
            visible = SafeDictionary.GetValue<int>(dic, "visible");
            title = SafeDictionary.GetValue<string>(dic, "title");
            subTitle = SafeDictionary.GetValue<string>(dic, "subTitle");
            achieveIcon = SafeDictionary.GetValue<string>(dic, "achieveIcon");
            step = SafeDictionary.GetValue<int>(dic, "step");
            createTime = SafeDictionary.GetValue<long>(dic, "createTime");
            showOrder = SafeDictionary.GetValue<int>(dic, "showOrder");
            fullReached = SafeDictionary.GetValue<bool>(dic, "fullReached");
            reachedStep = SafeDictionary.GetValue<int>(dic, "reachedStep");
            reachedTime = SafeDictionary.GetValue<long>(dic, "reachedTime");
            isChanged = SafeDictionary.GetValue<bool>(dic, "isChanged");
            type = SafeDictionary.GetValue<int>(dic, "type");
            if (Platform.IsIOS())
            {
                Debug.Log($"AchievementStats:{SafeDictionary.GetValue<string>(dic, "stats")}");
                stats = new AchievementStats(SafeDictionary.GetValue<string>(dic, "stats"));
            }
            else if (Platform.IsAndroid())
            {
                if (SafeDictionary.GetValue<Dictionary<string, object>>(dic, "stats") is Dictionary<string, object>
                    statsDic)
                {
                    stats = new AchievementStats(statsDic);
                }
            }
        }
    }


    public class AchievementStats
    {
        public int level;

        public double rarity;

        public AchievementStats(Dictionary<string, object> dic)
        {
            level = SafeDictionary.GetValue<int>(dic, "level");
            rarity = SafeDictionary.GetValue<double>(dic, "rarity");
        }

        public AchievementStats(string json)
        {
            var dic = Json.Deserialize(json) as Dictionary<string, object>;
            level = SafeDictionary.GetValue<int>(dic, "level");
            rarity = SafeDictionary.GetValue<double>(dic, "rarity");
        }
        
    }
}