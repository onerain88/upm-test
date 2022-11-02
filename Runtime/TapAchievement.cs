using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapTap.Bootstrap;
using TapTap.Common;

namespace TapTap.Achievement
{
    public class TapAchievement
    {
        public static void Init(TapConfig config)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().Init(config);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void RegisterCallback(IAchievementCallback callback)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().RegisterCallback(callback);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void InitData()
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().InitData();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void FetchAllAchievementList(Action<List<TapAchievementBean>, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().FetchAllAchievementList(action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void GetLocalAllAchievementList(Action<List<TapAchievementBean>, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().GetLocalAllAchievementList(action);
#else
            throw new System.NotImplementedException();
#endif
        }


        public static void GetLocalUserAchievementList(Action<List<TapAchievementBean>, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().GetLocalUserAchievementList(action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void FetchUserAchievementList(Action<List<TapAchievementBean>, TapError> action)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().FetchUserAchievementList(action);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static Task<List<TapAchievementBean>> FetchAllAchievementList()
        {
#if UNITY_IOS || UNITY_ANDROID
            return TapAchievementImpl.GetInstance().FetchAllAchievementList();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static Task<List<TapAchievementBean>> GetLocalUserAchievementList()
        {
#if UNITY_IOS || UNITY_ANDROID
            return TapAchievementImpl.GetInstance().GetLocalUserAchievementList();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static Task<List<TapAchievementBean>> GetLocalAllAchievementList()
        {
#if UNITY_IOS || UNITY_ANDROID
            return TapAchievementImpl.GetInstance().GetLocalAllAchievementList();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static Task<List<TapAchievementBean>> FetchUserAchievementList()
        {
#if UNITY_IOS || UNITY_ANDROID
            return TapAchievementImpl.GetInstance().FetchUserAchievementList();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void Reach(string id)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().Reach(id);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void GrowSteps(string id, int step)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().GrowSteps(id, step);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void MakeSteps(string id, int step)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().MakeSteps(id, step);
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void ShowAchievementPage()
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().ShowAchievementPage();
#else
            throw new System.NotImplementedException();
#endif
        }

        public static void SetShowToast(bool showToast)
        {
#if UNITY_IOS || UNITY_ANDROID
            TapAchievementImpl.GetInstance().SetShowToast(showToast);
#else
            throw new System.NotImplementedException();
#endif
        }
    }
}
