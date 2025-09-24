using System.Text.Json;
using System.Text.Json.Serialization;

namespace Patient_Portal.WebApi
{
    public static class WebApiSettings
    {
        private static JsonSerializerOptions _options;
        public static JsonSerializerOptions GetJsonSerializerOptions()
        {
            if (_options == null)
            {
                //_options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true };
                //_options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
                _options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve, PropertyNameCaseInsensitive = true };
            }

            return _options;
        }

        public const string REQUEST_HEADER_ACCEPT_JSON = "application/json";
        public const string REQUEST_HEADER_ACCEPT = "Accept";
    }
}
