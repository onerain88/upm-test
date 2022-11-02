using TapTap.Common;

namespace TapTap.Login.Internal
{
    public class LoginLanguage
    {
        private static volatile LoginLanguage _instance;
        private static readonly object ObjLock = new object();
        private LoginLangCN cn;
        private LoginLangIO io;

        private static LoginLanguage Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (ObjLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoginLanguage();
                    }
                }

                return _instance;
            }
        }

        private LoginLanguage()
        {
            cn = new LoginLangCN();
            io = new LoginLangIO();
        }

        public static ILoginLang GetCurrentLang()
        {
            switch (TapLocalizeManager.GetCurrentLanguage())
            {
                case TapLanguage.ZH_HANS:
                    return Instance.cn;
                default:
                    return Instance.io;
            }
        }
    }

    public class LoginLangCN : ILoginLang
    {
        public string TitleUse()
        {
            return "使用";
        }

        public string TitleLogin()
        {
            return "账号登录";
        }

        public string QrTitleLogin()
        {
            return "安全扫码登录";
        }

        public string QrRefresh()
        {
            return "点击刷新";
        }

        public string QrNoticeUse()
        {
            return "请使用";
        }

        public string QrNoticeClient()
        {
            return "客户端";
        }

        public string QrNoticeScanToLogin()
        {
            return "扫描二维码登录";
        }

        public string WebLogin()
        {
            return "使用网页浏览器完成授权";
        }

        public string WebNotice()
        {
            return "点击下方按钮前往网页浏览器，\n授权 TapTap 账号，完成后将自动返回游戏。";
        }
        
        public string WebButtonJumpToWeb()
        {
            return "跳转至 TapTap";
        }

        public string QrNoticeCancel()
        {
            return "您已取消此次登录";
        }

        public string QrNoticeCancel2()
        {
            return "请重新扫码";
        }

        public string QrnNoticeSuccess()
        {
            return "扫码成功";
        }

        public string QrnNoticeSuccess2()
        {
            return "请在手机上确认";
        }

        public string WebNoticeLogin()
        {
            return "正在登录中，请稍后";
        }

        public string WebNoticeFail()
        {
            return "登录失败";
        }

        public string WebNoticeFail2()
        {
            return "请重新点击打开网页进行授权";
        }
    }

    public class LoginLangIO : ILoginLang
    {
        public string TitleUse()
        {
            return "Log In with";
        }

        public string TitleLogin()
        {
            return "";
        }

        public string QrTitleLogin()
        {
            return "Via QR Code";
        }

        public string QrRefresh()
        {
            return "Refresh";
        }

        public string QrNoticeUse()
        {
            return "Use";
        }

        public string QrNoticeClient()
        {
            return "App";
        }

        public string QrNoticeScanToLogin()
        {
            return "to scan the code";
        }

        public string WebLogin()
        {
            return "Via Web Browser";
        }

        public string WebNotice()
        {
            return "Allow permission to log in with TapTap,\nYou'll be redirected back after login.";
        }

        public string WebButtonJumpToWeb()
        {
            return "Go to TapTap";
        }
        
        public string QrNoticeCancel()
        {
            return "Failed to log in";
        }

        public string QrNoticeCancel2()
        {
            return "Please try again";
        }

        public string QrnNoticeSuccess()
        {
            return "Success";
        }

        public string QrnNoticeSuccess2()
        {
            return "Please confirm login on your phone";
        }

        public string WebNoticeLogin()
        {
            return "Logging in";
        }

        public string WebNoticeFail()
        {
            return "Failed to log in";
        }

        public string WebNoticeFail2()
        {
            return "Please try again";
        }
    }


    public interface ILoginLang
    {
        string TitleUse();

        string TitleLogin();

        string QrTitleLogin();

        string QrRefresh();

        string QrNoticeUse();

        string QrNoticeClient();

        string QrNoticeScanToLogin();

        string WebLogin();

        string WebNotice();

        string WebButtonJumpToWeb();

        string QrNoticeCancel();

        string QrNoticeCancel2();

        string QrnNoticeSuccess();
        string QrnNoticeSuccess2();

        string WebNoticeLogin();

        string WebNoticeFail();

        string WebNoticeFail2();
    }
}