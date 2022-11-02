using TapTap.Common;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;

namespace TapTap.Bootstrap
{
    public class TapDBStartTask : IStartTask
    {
        private const string ServiceName = "TDSTapDBService";

        private const string ServiceClz = "com.tds.tapdb.wrapper.TapDBService";

        private const string ServiceImpl = "com.tds.tapdb.wrapper.TapDBServiceImpl";

        public TapDBStartTask()
        {
            EngineBridge.GetInstance().Register(ServiceClz, ServiceImpl);
        }

        public void Invoke(TapConfig config)
        {
            if (config.DBConfig == null)
            {
                return;
            }

            if (!config.DBConfig.Enable)
            {
                return;
            }

            Dictionary<string, object> deviceProperties = config.DBConfig.DeviceLoginProperties;
            //if(deviceProperties == null)
            //{
            //    deviceProperties = new Dictionary<string, object>();
            //}

            // TapDB 初始化
            var command = new Command.Builder()
                .Service(ServiceName)
                .Method("init")
                .Args("clientId", config.ClientID)
                .Args("channel", config.DBConfig.Channel)
                .Args("gameVersion", config.DBConfig.GameVersion)
                .Args("region", (int)config.RegionType)
                .Args("properties",deviceProperties).CommandBuilder();
            EngineBridge.GetInstance().CallHandler(command);

            //调用方法，注册 THEMIS log  listener
            try
            {
                Assembly assembly = Assembly.Load("TapTap.TapDB");
                System.Type type = assembly.GetType("TapTap.TapDB.ThemisUtil");
                if (type != null)
                {
                    MethodInfo method = type.GetMethod("RegisterUnityLogListener", new System.Type[] { });
                    if(method != null){
                       method.Invoke(null, new object[] { });
                    }
                }
                else
                {
                    Debug.Log("THEMIS not package ");
                }
            }catch(System.Exception e)
            {
                Debug.Log("THEMIS try to invoke register log listener fail " + e);
            }

            if (!Platform.IsIOS()) return;

            var idfaCommand = new Command.Builder()
                .Service(ServiceName)
                .Method("advertiserIDCollectionEnabled")
                .Args("advertiserIDCollectionEnabled", config.DBConfig.AdvertiserIDCollectionEnabled == true ? 1 : 0)
                .CommandBuilder();

            // 触发 TapDB IDFA 开关
            EngineBridge.GetInstance().CallHandler(idfaCommand);
        }
    }
}