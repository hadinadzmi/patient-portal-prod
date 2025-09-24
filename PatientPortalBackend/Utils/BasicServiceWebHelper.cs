using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PatientPortalBackend.DbModels;
using PatientPortalBackend.Models;
using PatientPortalBackend.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;
using ZeroFormatter;

namespace PatientPortalBackend.Utils
{
    public static class BasicServiceWebHelper
    {
        public static T CreateFaultResponse<T>(string errorCode, string errorMessage) where T:ServiceBaseWebResponse
        {
            return CreateFaultResponse<T>(errorCode, new List<string>{errorMessage});
        }

        public static string CreateFaultResponseStr<T>(string errorCode, string errorMessage)
            where T : ServiceBaseWebResponse
        {
            return CreateFaultResponseStr<T>(errorCode, new List<string> {errorMessage});
        }

        public static string CreateFaultResponseStr<T>(string errorCode, List<string> errorMessages) where T : ServiceBaseWebResponse
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            var resp = CreateFaultResponse<T>(errorCode, errorMessages);
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, resp);
            ms.Position = 0;
            var reader = new StreamReader(ms);
            var str = reader.ReadToEnd();
            return str;
        }

        public static T CreateFaultResponse<T>(string errorCode, List<string> errorMessages) where T:ServiceBaseWebResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T));
            response.Success = false;
            response.ErrorCode = errorCode;
            response.ErrorMessages = errorMessages;
            return response;
        }

        public static string CreateSuccessResponseStr<T>() where T : ServiceBaseWebResponse
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            var resp = CreateSuccessResponse<T>();
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, resp);
            ms.Position = 0;
            var reader = new StreamReader(ms);
            var str = reader.ReadToEnd();
            return str;
        }

        public static T CreateSuccessResponse<T>() where T:ServiceBaseWebResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T));
            response.Success = true;
            response.ErrorCode = "O000";
            return response;
        }

        public static bool ValidateBaseWebRequest(IHttpClientFactory httpFact, ServiceBaseWebRequest request, out string errorCode, out string errorMsg, out string iisUrl, out ServiceBaseRequest mcBaseRequest)
        {
            mcBaseRequest = null;
            iisUrl = String.Empty;
            if (String.IsNullOrWhiteSpace(request.UserNamePatientPortal))
            {
                errorCode = "101";
                errorMsg = "The username is not set!";
                return false;
            }
            if (String.IsNullOrWhiteSpace(request.TenantKey))
            {
                errorCode = "102";
                errorMsg = "The tenant key is not set!";
                return false;
            }

            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                Guid tenGuid;
                if (!Guid.TryParse(request.TenantKey, out tenGuid))
                {
                    errorCode = "102";
                    errorMsg = "The tenant key is invalid!";
                    return false;
                }
                var tenExt =
                    context.TenantExtension.FirstOrDefault(p => p.PatientPortalUserName == request.UserNamePatientPortal && tenGuid == p.TenantGuid);

                if (tenExt == null)
                {
                    errorCode = "103";
                    errorMsg = "No login found for user and tenant key!";
                    return false;
                }
                iisUrl = tenExt.MedCubesIisUrl;

                var authenticateUserResponse = AuthenticateUser(httpFact, request, iisUrl, tenExt);
                if (!authenticateUserResponse.Success)
                {
                    errorCode = authenticateUserResponse.ErrorCode;
                    //authenticateUserResponse.ServiceMessages[0] = request.PasswordEncStr;
                    errorMsg = String.Join(";", authenticateUserResponse.ServiceMessages);
                    return false;
                }

                mcBaseRequest = new ServiceBaseRequest
                {
                    ClientCustomerId = tenExt.CustomerId,
                    ClientTenantId = tenExt.TenantId,
                    ClientToken = authenticateUserResponse.AuthenticationToken,
                    ClientUserId = authenticateUserResponse.User.UserId,
                    ClientUserName = tenExt.ResolvedUserName
                };
            }

            errorCode = "O000";
            errorMsg = String.Empty;
            return true;
        }

        public static T CreateMedCubesFaultResponse<T>(Exception e) where T:ServiceBaseResponse
        {
            var resp = Activator.CreateInstance<T>();
            resp.Success = false;
            resp.ErrorCode = "T100";
            resp.ServiceMessages = new List<string>(1) {e.ToString()};
            return resp;
        }

        public static T CreateMedCubesRequest<T>(PortalSettings portalSettings, ServiceBaseRequest mcBaseRequest) where T : ServiceBaseRequest
        {
            var request = Activator.CreateInstance<T>();
            request.ClientCustomerId = mcBaseRequest.ClientCustomerId;
            request.ClientTenantId = mcBaseRequest.ClientTenantId;
            request.ClientUserId = mcBaseRequest.ClientUserId;
            request.ClientUserName = mcBaseRequest.ClientUserName;
            request.ClientToken = mcBaseRequest.ClientToken;
            request.IsChildTransaction = false;
            request.TransactionId = Guid.Parse(portalSettings.MedCubesTransactionId);
            return request;
        }

        private static ServiceUserAuthenticationResponse AuthenticateUser(IHttpClientFactory httpFact, ServiceBaseWebRequest request, string iisUrl, TenantExtension tenExt)
        {
            var req = new ServiceUserAuthenticationRequest
            {
                UserName = tenExt.ResolvedUserName,
                Password = Convert.FromBase64String(request.PasswordEncStr),
                NoPasswordExpirationCheck = true,
                ClientCustomerId = tenExt.CustomerId,
                ClientTenantId = tenExt.TenantId
            };

            var userAuthResponse =
                CallMedCubesService<ServiceUserAuthenticationResponse, ServiceUserAuthenticationRequest>(httpFact, req, iisUrl,
                    "Login/UserAuthentication");

            return userAuthResponse;
        }

        public static T CallMedCubesService<T, TU>(IHttpClientFactory httpFact, TU request, string iisUrl, string endpoint) where T : ServiceBaseResponse where TU : ServiceBaseRequest
        {
            return CallMedCubesServiceAsync<T, TU>(httpFact, request, iisUrl, endpoint).Result;
        }

        public static async Task<T> CallMedCubesServiceAsync<T, TU>(IHttpClientFactory httpFact, TU request, string iisUrl, string endpoint) where T : ServiceBaseResponse where TU : ServiceBaseRequest
        {
            try
            {
                var fullServiceUri = UrlHelper.GetUrl(iisUrl, endpoint);
                var serialized = JsonSerializer.Serialize(request, request.GetType(), GetJsonSerializerOptions());
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, fullServiceUri);
                var acceptHeader = GetAcceptHeader(WebRequestHelperFormatType.Json);
                httpRequestMessage.Headers.Add(REQUEST_HEADER_ACCEPT, acceptHeader);
                var httpClient = httpFact.CreateClient();
                httpRequestMessage.Content = new StringContent(serialized, Encoding.UTF8, JSON_FORMAT);
                var responseStr = await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
                responseStr.EnsureSuccessStatusCode();

                //var deseri = await responseStr.Content.ReadAsStringAsync();
                //var tmp = JsonSerializer.Deserialize<T>(deseri, GetJsonSerializerOptions());
                //Debug.WriteLine(deseri);

                using (var stream = await responseStr.Content.ReadAsStreamAsync())
                {
                    var response = await JsonSerializer.DeserializeAsync<T>(stream, GetJsonSerializerOptions());
                    return response;
                }
            }
            catch (Exception e)
            {
                return CreateMedCubesFaultResponse<T>(e);
            }
        }

        private static JsonSerializerOptions _jsonSerOptions;
        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            if (_jsonSerOptions == null)
            {
                //_options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true };
                _jsonSerOptions = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve };
            }

            return _jsonSerOptions;
        }

        private const string REQUEST_HEADER_ACCEPT = "Accept";
        private const string REQUEST_HEADER_ACCEPT_MPC = "application/x-msgpack";
        private const string REQUEST_HEADER_ACCEPT_JSON = "application/json";
        private const string REQUEST_HEADER_ACCEPT_XML = "application/xml";
        private const string REQUEST_HEADER_ACCEPT_ZEROFORMATTER = "application/octet-stream";
        private const string JSON_FORMAT = "application/json";

        private static string GetAcceptHeader(WebRequestHelperFormatType formatType)
        {
            switch (formatType)
            {
                case WebRequestHelperFormatType.MessagePack:
                    return REQUEST_HEADER_ACCEPT_MPC;
                case WebRequestHelperFormatType.Json:
                    return REQUEST_HEADER_ACCEPT_JSON;
                case WebRequestHelperFormatType.Xml:
                    return REQUEST_HEADER_ACCEPT_XML;
                case WebRequestHelperFormatType.ZeroFormatter:
                    return REQUEST_HEADER_ACCEPT_ZEROFORMATTER;
            }

            return REQUEST_HEADER_ACCEPT_JSON;
        }

        public enum WebRequestHelperFormatType
        {
            Xml = 1,
            Json = 2,
            MessagePack = 3,
            ZeroFormatter = 4
        }
    }


}
