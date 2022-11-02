using System.Collections.Generic;
using TapTap.Common;

namespace TapTap.Bootstrap
{
    public class TapBillboardStartTask : IStartTask
    {
        private const string ServiceName = "TDSBillboardService";

        private const string ServiceClz = "com.tapsdk.billboard.wrapper.TDSBillboardService";

        private const string ServiceImpl = "com.tapsdk.billboard.wrapper.TDSBillboardServiceImpl";

        private const string InitMethod = "init";

        public TapBillboardStartTask()
        {
            EngineBridge.GetInstance().Register(ServiceClz, ServiceImpl);
        }

        public void Invoke(TapConfig config)
        {
            var command = new Command.Builder()
                .Service(ServiceName)
                .Method(InitMethod)
                .Args("initWithConfig", config.ToJson())
                .CommandBuilder();
            EngineBridge.GetInstance().CallHandler(command);
        }
    }
}