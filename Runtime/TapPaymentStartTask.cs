using System.Collections.Generic;
using TapTap.Common;

namespace TapTap.Bootstrap
{
    public class TapPaymentStartTask : IStartTask
    {
        private const string ServiceName = "TDSPaymentService";

        private const string ServiceClz = "com.tapsdk.payment.wrapper.TDSPaymentService";

        private const string ServiceImpl = "com.tapsdk.payment.wrapper.TDSPaymentServiceImpl";

        private const string InitMethod = "init";

        public TapPaymentStartTask()
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