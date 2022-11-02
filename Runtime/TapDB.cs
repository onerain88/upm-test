using System;
using UnityEngine;
using System.Collections.Generic;


namespace TapTap.TapDB
{
    public class TapDB
    {
        public delegate void LogCallbackDelegate(string condition, string stackTrace, LogType type);

        public static void Init(string clientId, string channel, string gameVersion, bool isCN)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().Init(clientId, channel, gameVersion, isCN);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Init(string clientId, string channel, string gameVersion, TapDBRegion region, Dictionary<string, object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().Init(clientId, channel, gameVersion, region, properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetUser(string userId)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().SetUser(userId);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetUser(string userId, string loginType)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().SetUser(userId, loginType);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetUserWithProperties(string userId, Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().SetUserWithProperties(userId, properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetName(string name)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().SetName(name);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetLevel(int level)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().SetLevel(level);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetServer(string server)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().SetServer(server);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void OnCharge(string orderId, string product, long amount, string currencyType, string payment)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().OnCharge(orderId, product, amount, currencyType, payment);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void OnCharge(string orderId, string product, long amount, string currencyType, string payment, string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().OnCharge(orderId, product, amount, currencyType, payment, properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void OnCharge(string orderId, string product, long amount, string currencyType, string payment, Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().OnCharge(orderId, product, amount, currencyType, payment, properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        [Obsolete("已弃用,请调用trackEvent(string eventName, Dictionary<string, object> properties)")]
        public static void OnEvent(string eventCode, string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().OnEvent(eventCode, properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void TrackEvent(string eventName, string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().TrackEvent(eventName, properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void TrackEvent(string eventName, Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().TrackEvent(eventName, properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void RegisterStaticProperties(string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().RegisterStaticProperties(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void RegisterStaticProperties(Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().RegisterStaticProperties(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UnregisterStaticProperty(string propertKey)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UnregisterStaticProperty(propertKey);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void RegisterDynamicProperties(IDynamicProperties properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().RegisterDynamicProperties(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void ClearStaticProperties()
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().ClearStaticProperties();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void DeviceInitialize(string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().DeviceInitialize(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void DeviceInitialize(Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().DeviceInitialize(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void DeviceUpdate(string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().DeviceUpdate(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void DeviceUpdate(Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().DeviceUpdate(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void DeviceAdd(string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().DeviceAdd(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void DeviceAdd(Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().DeviceAdd(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UserInitialize(string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UserInitialize(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UserInitialize(Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UserInitialize(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UserUpdate(string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UserUpdate(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UserUpdate(Dictionary<string, object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UserUpdate(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UserAdd(string properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UserAdd(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UserAdd(Dictionary<string,object> properties)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UserAdd(properties);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void EnableLog(bool enable)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().EnableLog(enable);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void AdvertiserIDCollectionEnabled(bool enable)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().AdvertiserIDCollectionEnabled(enable);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void CloseFetchTapTapDeviceId()
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().CloseFetchTapTapDeviceId();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void ClearUser()
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().ClearUser();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void GetTapTapDid(Action<string> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().GetTapTapDid(action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void ConfigAutoReportLogLevel(LogSeverity level)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().ConfigAutoReportLogLevel(level);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void ConfigAutoQuitApplication(bool enable)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().ConfigAutoQuitApplication(enable);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void RegisterLogCallback(TapDB.LogCallbackDelegate handler)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().RegisterLogCallback(handler);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void UnRegisterLogCallback(TapDB.LogCallbackDelegate handler)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().UnRegisterLogCallback(handler);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void ReportException(System.Exception e, string message)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapDBImpl.GetInstance().ReportException(e, message);
#else
            throw new System.NotImplementedException();
#endif
        }
    }
}
