using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapTap.Bootstrap;
using TapTap.Common;

namespace TapTap.Payment
{
    public interface ITapPayment
    {
        void Init(TapConfig tapConfig);

        Boolean IsReady();

        void QueryProduct(string skuId, Action<SkuDetails, TapError> action);

        void QueryProducts(string[] skuIds, Action<List<SkuDetails>, TapError> action);

        void LaunchBillingFlow(SkuDetails skuDetails, String roleId, String serverId, String extra, Action<int, TapError> action);
    }

    public static class TapPaymentConstants
    {
        public static readonly string TapPaymentService = "TDSPaymentService";

        public static readonly string TapPaymentClz = "com.tapsdk.payment.wrapper.TDSPaymentService";

        public static readonly string TapPaymentImpl = "com.tapsdk.payment.wrapper.TDSPaymentServiceImpl";
    }
}