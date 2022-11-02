using System;

namespace TapTap.License
{
    public class TapLicense
    {
        public static void SetLicenseCallBack(ITapLicenseCallback callback)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapLicenseImpl.GetInstance().SetLicencesCallback(callback);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetDLCCallback(ITapDlcCallback callback)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapLicenseImpl.GetInstance().SetDLCCallback(callback);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetDLCCallback(ITapDlcCallback callback, bool checkOnce, string publicKey)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapLicenseImpl.GetInstance().SetDLCCallback(callback, checkOnce, publicKey);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Check()
        {
#if UNITY_IOS || UNITY_ANDROID
            TapLicenseImpl.GetInstance().Check();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void QueryDLC(string[] dlcList)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapLicenseImpl.GetInstance().QueryDLC(dlcList);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void PurchaseDLC(string dlc)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapLicenseImpl.GetInstance().PurchaseDLC(dlc);
#else
            throw new System.NotImplementedException();
#endif
        }
    }
}
