using Microsoft.AspNetCore.Components.Web;
using Patient_Portal.Core;
using Patient_Portal.MessageBox;
using Patient_Portal.WebApi;
using PatientPortalBackend.Models;

namespace Patient_Portal.Pages
{
    public partial class LoginPageView : McComponentBase
    {
        public string PatientNRIC { get; set; } = "";
        public string PatientPaswrd { get; set; }
        private bool isPasswordVisible = false; // Added property to manage password visibility

        private bool showErrorModal = false;
        private string modalMessage = string.Empty;

        private async Task HandleValidSubmit(MouseEventArgs arg)
        {
            // Validation: Check if both fields are filled
            if (string.IsNullOrWhiteSpace(PatientNRIC) || string.IsNullOrWhiteSpace(PatientPaswrd))
            {
                ShowErrorModal("Please enter both NRIC/Passport Number and Password.");
                return;
            }

            SetBusy(true);

            var request = new ServiceGetLoginDetailsRequest()
            {
                PatientNric = PatientNRIC,
                PatientPassword = PatientPaswrd
            };
            await Task.Delay(3000);

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceGetLoginDetailsResponse, ServiceGetLoginDetailsRequest>(_httpClient, request,
                    ServiceUris.GetLoginDetailsUri);

            if (!response.Success)
            {
                ShowErrorModal(string.Join(", ", response.ErrorMessages));
                SetBusy(false);
                return;
            }
            else
            {
                await GlobalData.SetUserData(LocalStorage, response.PatId, response.PatNRIC, response.PatName, response.PatMobileNum, response.PatDOB);
                NavigationManager.NavigateTo("/senalogin", false, true);
            }

            SetBusy(false);
        }

        private void TogglePasswordVisibility()
        {
            isPasswordVisible = !isPasswordVisible;
        }

        private void ShowErrorModal(string message)
        {
            modalMessage = message;
            showErrorModal = true;
        }

        private void CloseModal()
        {
            showErrorModal = false;
            modalMessage = string.Empty;
        }
    }
}
