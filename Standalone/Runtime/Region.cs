namespace TapTap.Login.Internal
{
    public abstract class Region
    {
        protected abstract string WebHost();

        protected abstract string ApiHost();

        protected abstract string AccountHost();

        public string CodeUrl()
        {
            return WebHost() + "/oauth2/v1/device/code";
        }

        public string TokenUrl()
        {
            return WebHost() + "/oauth2/v1/token";
        }

        public string ProfileUrl()
        {
            return ApiHost() + "/account/profile/v1?client_id=";
        }

        public string AccountUrl()
        {
            return AccountHost() + "/authorize?";
        }
    }

    public class RegionCN : Region
    {
        protected override string WebHost()
        {
            return "https://www.taptap.com";
        }

        protected override string ApiHost()
        {
            return "https://openapi.taptap.com";
        }

        protected override string AccountHost()
        {
            return "https://accounts.taptap.com";
        }
    }

    public class RegionIO : Region
    {
        protected override string WebHost()
        {
            return "https://www.taptap.io";
        }

        protected override string ApiHost()
        {
            return "https://openapi.tap.io";
        }

        protected override string AccountHost()
        {
            return "https://accounts.taptap.io";
        }
    }
}