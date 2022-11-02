using System.Collections.Generic;
using System.Threading.Tasks;

namespace TapTap.Support.Internal.Platform {
    public interface ITapSupport {
        void Init(string serverUrl, string rootCategoryId, TapSupportDelegate supportDelegate);
        void SetDefaultMetaData(Dictionary<string, object> metaData);
        void SetDefaultFieldsData(Dictionary<string, object> fieldsData);
        void LoginAnonymously(string userId);
        Task<string> GetSupportWebUrl(string path = null,
            Dictionary<string, object> metaData = null,
            Dictionary<string, object> fieldsData = null);
        void OpenSupportView(string path = null,
            Dictionary<string, object> metaData = null,
            Dictionary<string, object> fieldsData = null);
        void CloseSupportView();
        void Resume();
        void Pause();
        void FetchUnReadStatus();
    }
}
