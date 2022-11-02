using System;
using TapTap.Common;

namespace TapTap.Bootstrap {
    public class TapSupportStartTask : IStartTask {
        private const string ServiceClz = "com.tds.tapsupport.wrapper.TapSupportService";

        private const string ServiceImpl = "com.tds.tapsupport.wrapper.TapSupportServiceImpl";

        public TapSupportStartTask() {
            EngineBridge.GetInstance().Register(ServiceClz, ServiceImpl);
        }

        public void Invoke(TapConfig config) {
        }
    }
}
