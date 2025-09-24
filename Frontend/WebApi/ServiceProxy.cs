using System.Text;
using System.Text.Json;
using Patient_Portal.Core;
using Patient_Portal.MessageBox;
using Patient_Portal.Pages;
using PatientPortalBackend.Models;

namespace Patient_Portal.WebApi
{
    public class ServiceProxy
    {
        private McComponentBase _baseComp;
        private UserForgotPassPageView userForgotPassPageView;
        private FirstTimeLoginPageView firstTimeLoginPageView;

        public ServiceProxy(McComponentBase baseComp)
        {
            _baseComp = baseComp;
        }

        public ServiceProxy(UserForgotPassPageView userForgotPassPageView)
        {
            this.userForgotPassPageView = userForgotPassPageView;
        }

        public ServiceProxy(FirstTimeLoginPageView firstTimeLoginPageView)
        {
            this.firstTimeLoginPageView = firstTimeLoginPageView;
        }

        public async Task<T> CallWebApi<T, TU>(HttpClient httpClient, TU request, Uri fullServiceUri)
            where T : ServiceBaseWebResponse
        {
            var jsonOptions = WebApiSettings.GetJsonSerializerOptions();
            var serialized = JsonSerializer.Serialize(request, jsonOptions);

            //TEST fake response for Login
            //if (typeof(T) == typeof(ServiceGetLoginDetailsResponse))
            //{
            //    await Task.Delay(500);
            //    var response = new ServiceGetLoginDetailsResponse();
            //    response.Success = true;
            //    response.PatientId = Guid.NewGuid();
            //    return response as T;
            //}

            try
            {
                _baseComp?.SetBusy(true);
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, fullServiceUri);
                var acceptHeader = WebApiSettings.REQUEST_HEADER_ACCEPT_JSON;
                httpRequestMessage.Headers.Add(WebApiSettings.REQUEST_HEADER_ACCEPT, acceptHeader);
                httpRequestMessage.Content =
                    new StringContent(serialized, Encoding.UTF8, WebApiSettings.REQUEST_HEADER_ACCEPT_JSON);
                var responseStr =
                    await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
                responseStr.EnsureSuccessStatusCode();
                using (var stream = await responseStr.Content.ReadAsStreamAsync())
                {
                    var response = await JsonSerializer.DeserializeAsync<T>(stream, jsonOptions);
                    return response;
                }
            }
            catch (Exception e)
            {
                var response = (T)Activator.CreateInstance(typeof(T));
                response.ErrorCode = "EXC101";
                response.ErrorMessages = new List<string> { e.ToString() };
                return response;
            }
            finally
            {
                _baseComp?.SetBusy(false);
            }
        }
    }
}
