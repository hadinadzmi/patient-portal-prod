using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Options;
using PatientPortalBackend.Utils;

namespace PatientPortalBackend.Controllers
{
    public class PortalBaseController : ControllerBase
    {
        protected IHttpClientFactory _httpClientFactory;
        protected PortalSettings _portalSettings;
        public PortalBaseController(IHttpClientFactory httpClientFactory, IOptions<PortalSettings> portalSettings)
        {
            _httpClientFactory = httpClientFactory;
            _portalSettings = portalSettings.Value;
        }
    }
}
