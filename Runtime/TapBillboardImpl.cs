using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapTap.Bootstrap;
using TapTap.Common;
using UnityEngine;

namespace TapTap.Billboard
{
    public class TapBillboardImpl : ITapBillboard
    {

        private static AndroidJavaObject androidJavaNativePayment;

        private TapBillboardImpl()
        {
            EngineBridge.GetInstance()
                .Register(TapBillboardConstants.TapBillboardClz, TapBillboardConstants.TapBillboardImpl);
        }

        private class PlatformNotSupportedException : Exception
        {
            public PlatformNotSupportedException() : base()
            {

            }
        }

        private static volatile TapBillboardImpl _sInstance;

        private static readonly object Locker = new object();

        public static TapBillboardImpl GetInstance()
        {
            lock (Locker)
            {
                if (_sInstance == null)
                {
                    _sInstance = new TapBillboardImpl();
                    androidJavaNativePayment = new AndroidJavaObject(TapBillboardConstants.TapBillboardImpl); 
                }
            }

            return _sInstance;
        }

        public void Init(TapConfig tapConfig)
        {
            EngineBridge.GetInstance().CallHandler(
                new Command.Builder()
                    .Service(TapBillboardConstants.TapBillboardService)
                    .Method("init")
                    .Args("initWithConfig", tapConfig.ToJson())
                    .CommandBuilder());
        }

        public void OpenPanel(Action<bool, TapError> action) {
            EngineBridge.GetInstance().CallHandler(
               new Command.Builder()
               .Service(TapBillboardConstants.TapBillboardService)
               .Method("openPanel")
               .Callback(true)
               .OnceTime(true)
               .CommandBuilder(), result => { HandlerOpenPanelResult(action, result); });           
        }

        public void QueryBadgeDetails(Action<BadgeDetails, TapError> action)
        {
            EngineBridge.GetInstance().CallHandler(
                new Command.Builder()
                .Service(TapBillboardConstants.TapBillboardService)
                .Method("queryBadgeDetails")
                .Callback(true)
                .OnceTime(true)
                .CommandBuilder(), result => { HandlerBadgeDetailsResult(action, result); });
        }

        public void RegisterCustomLinkListener(Action<String> action) {
            EngineBridge.GetInstance().CallHandler(
                new Command.Builder()
                .Service(TapBillboardConstants.TapBillboardService)
                .Method("registerCustomLinkListener")
                .Callback(true)
                .OnceTime(false)
                .CommandBuilder(), result => { HandlerRegisterResult(action, result); });
        }

        public void UnRegisterCustomLinkListener(Action<String> action) {
            EngineBridge.GetInstance().CallHandler(
                new Command.Builder()
                .Service(TapBillboardConstants.TapBillboardService)
                .Method("unRegisterCustomLinkListener")
                .Callback(true)
                .OnceTime(true)
                .CommandBuilder());
        }

        private static bool CheckResult(Result result)
        {
            if (result.code != Result.RESULT_SUCCESS)
            {
                return false;
            }

            return !string.IsNullOrEmpty(result.content);
        }

        private static void HandlerOpenPanelResult(Action<bool, TapError> action, Result result) {
            if (!CheckResult(result))
            {
                action(false, new TapError(19999, "Bridge execute Billboard Error"));
                return;
            }       

            var openPanelResultWrapper = new OpenPanelResultWrapper(result.content);
            if (openPanelResultWrapper.error != null)
            {
                action(false, openPanelResultWrapper.error);
            } else {
                action(openPanelResultWrapper.openResult, null);
            }
        }

        private static void HandlerBadgeDetailsResult(Action<BadgeDetails, TapError> action, Result result)
        {
            if (!CheckResult(result))
            {
                action(null, new TapError(19999, "Bridge execute Billboard Error"));
                return;
            }

            var badgeDetailsWrapper = new BadgeDetailsWrapper(result.content);
            if (badgeDetailsWrapper.error != null)
            {
                action(null, badgeDetailsWrapper.error);
            }
            else
            {
                if (badgeDetailsWrapper.badgeDetails != null)
                {
                    action(badgeDetailsWrapper.badgeDetails, null);
                }
                else
                {
                    action(null, null);
                }
            }
        }
  
        private static void HandlerRegisterResult(Action<string> action, Result result)
        {
            if (!CheckResult(result))
            {
                action("");
                return;
            }
            var customLink = "";
            if (result != null && result.content != null && result.content.Length > 0)
            {
                customLink = result.content;
            }
            action(customLink);
        }
    }
}