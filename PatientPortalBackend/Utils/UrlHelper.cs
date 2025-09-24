using System.IO;
using System.Security.Policy;
using PatientPortalBackend.DbModels;

namespace PatientPortalBackend.Utils
{
    public static class UrlHelper
    {
        public static string GetUrl(TenantExtension tenantExt, string relativeServicePath)
        {
            return GetUrl(tenantExt.MedCubesIisUrl, relativeServicePath);
        }

        public static string GetUrl(string iisUrl, string relativeServicePath)
        {
            return $"{iisUrl.Trim('/')}/api/{relativeServicePath}";
        }
    }
}
