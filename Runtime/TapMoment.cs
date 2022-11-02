using System;
using TapTap.Common;
using System.Collections.Generic;

namespace TapTap.Moment
{
    public class TapMoment
    {
        public static void SetCallback(Action<int, string> callback)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().SetCallback(callback);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Init(string clientId)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().Init(clientId);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Init(string clientId, bool isCN)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().Init(clientId, isCN);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Open(Orientation config)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().Open(config);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Publish(Orientation config, string[] imagePaths, string content)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().Publish(config, imagePaths, content);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void PublishVideo(Orientation config, string[] videoPaths, string[] imagePaths, string title, string desc)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().PublishVideo(config, videoPaths, imagePaths, title, desc);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void PublishVideo(Orientation config, string[] videoPaths, string title, string desc)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().PublishVideo(config, videoPaths, title, desc);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void FetchNotification()
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().FetchNotification();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void DirectlyOpen(Orientation orientation, string page, Dictionary<string, object> extras)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().DirectlyOpen(orientation, page, extras);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Close()
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().Close();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Close(string title, string desc)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().Close(title, desc);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetGameScreenAutoRotate(bool auto)
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().SetUseAutoRotate(auto);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void NeedDeferSystemGestures()
        {
#if UNITY_IOS || UNITY_ANDROID
            MomentImpl.GetInstance().NeedDeferSystemGestures();
#else
            throw new System.NotImplementedException();
#endif
        }
        
    }
}
