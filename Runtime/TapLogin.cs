using System.Threading.Tasks;

namespace TapTap.Login
{
    public class TapLogin
    {
        public const string TAP_LOGIN_SCOPE_BASIC_INFO = "basic_info";
        public const string TAP_LOGIN_SCOPE_PUBLIC_PROFILE = "public_profile";
        public const string TAP_LOGIN_SCOPE_USER_FRIENDS = "user_friends";
        public const string TAP_LOGIN_SCOPE_EMAIL = "email";

        public static void Init(string clientID)
        {
            TapLoginImpl.GetInstance().Init(clientID);
        }

        public static void Init(string clientID, bool isCn, bool roundCorner)
        {
            TapLoginImpl.GetInstance().Init(clientID, isCn, roundCorner);
        }

        public static void ChangeConfig(bool roundCorner, bool isPortrait)
        {
            TapLoginImpl.GetInstance().ChangeConfig(roundCorner, isPortrait);
        }

        public static Task<Profile> FetchProfile()
        {
            return TapLoginImpl.GetInstance().FetchProfile();
        }

        public static Task<Profile> GetProfile()
        {
            return TapLoginImpl.GetInstance().GetProfile();
        }

        public static Task<AccessToken> GetAccessToken()
        {
            return TapLoginImpl.GetInstance().GetAccessToken();
        }

        public static Task<AccessToken> Login()
        {
            return TapLoginImpl.GetInstance().Login();
        }

        public static Task<AccessToken> Login(string[] permissions)
        {
            return TapLoginImpl.GetInstance().Login(permissions);
        }

        public static void Logout()
        {
            TapLoginImpl.GetInstance().Logout();
        }

        public static Task<bool> GetTestQualification()
        {
            return TapLoginImpl.GetInstance().GetTestQualification();
        }
    }
}