using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapTap.Bootstrap;
using TapTap.Common;

namespace TapTap.Payment
{
    public class TapPayment
    {
        public static void Init(TapConfig config)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapPaymentImpl.GetInstance().Init(config);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static Boolean IsReady()
        {
#if UNITY_IOS || UNITY_ANDROID
            return TapPaymentImpl.GetInstance().IsReady();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void QueryProduct(string skuId, Action<SkuDetails, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapPaymentImpl.GetInstance().QueryProduct(skuId, action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void QueryProducts(string[] skuIds, Action<List<SkuDetails>, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapPaymentImpl.GetInstance().QueryProducts(skuIds, action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void LaunchBillingFlow(SkuDetails skuDetails, String roleId, String serverId, String extra, Action<int, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapPaymentImpl.GetInstance().LaunchBillingFlow(skuDetails, roleId, serverId, extra, action);
#else
            throw new System.NotImplementedException();
#endif
        }
        
    }
}
