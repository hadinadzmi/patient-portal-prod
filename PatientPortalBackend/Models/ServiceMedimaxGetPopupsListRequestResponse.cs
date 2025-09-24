using PatientPortalBackend.Models.MedCubesModels;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxGetPopupsListRequest : ServiceBaseWebRequest
    {
        public string PtPopupKey { get; set; }
    }

    public class ServiceMedimaxGetPopupsListResponse : ServiceBaseWebResponse
    {
        public List<PopupEntry> PopupEntryList { get; set; }
    }
}
