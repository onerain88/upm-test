using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapTap.Bootstrap;
using TapTap.Common;

namespace TapTap.Billboard
{
    public class TapBillboard
    {
        public static void Init(TapConfig config)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapBillboardImpl.GetInstance().Init(config);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void QueryBadgeDetails(Action<BadgeDetails, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapBillboardImpl.GetInstance().QueryBadgeDetails(action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void OpenPanel(Action<bool, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapBillboardImpl.GetInstance().OpenPanel(action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void RegisterCustomLinkListener(Action<string> action) 
        {
#if UNITY_IOS || UNITY_ANDROID
            TapBillboardImpl.GetInstance().RegisterCustomLinkListener(action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UnRegisterCustomLinkListener(Action<string> action) 
        {
#if UNITY_IOS || UNITY_ANDROID
            TapBillboardImpl.GetInstance().UnRegisterCustomLinkListener(action);
#else
            throw new System.NotImplementedException();
#endif
        }
    }
}
