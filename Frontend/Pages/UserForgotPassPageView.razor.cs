using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Patient_Portal.WebApi;
using PatientPortalBackend.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Patient_Portal.Pages
{
    public partial class UserForgotPassPageView
    {
        private string MobileNumber;
        private string patientId; // Added Patient ID field
        private string otp1;
        private string otp2;
        private string otp3;
        private string otp4;
        private string otp5;
        private string otp6;
        private string newPassword;
        private string confirmPassword;
        private bool isOTPSent = false;
        private bool isOTPVerified = false;
        private bool isRedirecting = false;
        private bool _isBusy;

        private string modalMessage = string.Empty;
        private bool showErrorModal = false;

        private bool showSuccessModal = false;
        private string successMessage = string.Empty;

        private ElementReference otp1Ref;
        private ElementReference otp2Ref;
        private ElementReference otp3Ref;
        private ElementReference otp4Ref;
        private ElementReference otp5Ref;
        private ElementReference otp6Ref;

        [Inject]
        private IJSRuntime JS { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private async Task SendOTP(MouseEventArgs arg)
        {
            IsBusy = true;
            try
            {
                var request = new ServiceGetMaxConfirmationCodeRequest()
                {
                    patNRIC = patientId,
                    patMobileNum = MobileNumber,
                    RequestType = "ResetPassword"
                };

                await Task.Delay(2000); // 2-second delay before API call

                var prx = new ServiceProxy(this);
                var response =
                    await prx.CallWebApi<ServiceGetMaxConfirmationCodeResponse, ServiceGetMaxConfirmationCodeRequest>(Http, request,
                        ServiceUris.GetConfirmationCodeUri);

                if (response.Success)
                {
                    isOTPSent = true;
                    patientId = response.patID.ToString(); // Store the patID
                }
                else
                {
                    var message = (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                        ? string.Join(", ", response.ErrorMessages)
                        : "Failed to send OTP. Please check your input and try again.";
                    ShowErrorModal(message);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task VerifyOTP()
        {
            IsBusy = true;
            try
            {
                string otp = $"{otp1}{otp2}{otp3}{otp4}{otp5}{otp6}";

                var request = new ServiceMedimaxVerifyConfirmationCodeRequest
                {
                    PatientId = patientId,
                    ConfirmationCode = otp,
                    RequestType = "ResetPassword"
                };

                await Task.Delay(2000); // 2-second delay before API call

                var prx = new ServiceProxy(this);
                var response =
                    await prx.CallWebApi<ServiceMedimaxVerifyConfirmationCodeResponse, ServiceMedimaxVerifyConfirmationCodeRequest>(Http, request,
                        ServiceUris.VerifyConfirmationCodeUri);

                if (response.Success)
                {
                    isOTPVerified = true;
                    modalMessage = string.Empty;
                }
                else
                {
                    var message = (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                        ? string.Join(", ", response.ErrorMessages)
                        : "OTP verification failed. Please try again.";
                    ShowErrorModal(message);
                    ClearOTPFields();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task CreatePassword()
        {
            IsBusy = true;
            try
            {
                if (newPassword != confirmPassword)
                {
                    ShowErrorModal("Passwords do not match.");
                    return;
                }

                if (!IsPasswordValid(newPassword, out var validationError))
                {
                    ShowErrorModal(validationError);
                    return;
                }

                string otp = $"{otp1}{otp2}{otp3}{otp4}{otp5}{otp6}";

                var request = new ServiceMedimaxVerifyConfirmationCodeRequest
                {
                    PatientId = patientId,
                    ConfirmationCode = otp,
                    NewPassword = newPassword,
                    RequestType = "ResetPassword"
                };

                await Task.Delay(2000); // 2-second delay before API call

                var prx = new ServiceProxy(this);
                var response =
                    await prx.CallWebApi<ServiceMedimaxVerifyConfirmationCodeResponse, ServiceMedimaxVerifyConfirmationCodeRequest>(
                        Http, request, ServiceUris.SetPasswordAfterCodeUri);

                if (response.Success)
                {
                    successMessage = "Password changed successfully. Please log in with your new password.";
                    showSuccessModal = true;
                    StateHasChanged();
                }
                else
                {
                    var message = (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                        ? string.Join(", ", response.ErrorMessages)
                        : "Failed to set password. Please try again.";
                    ShowErrorModal(message);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }


        private async Task OnSuccessModalOk()
        {
            showSuccessModal = false;
            IsBusy = true;
            StateHasChanged();
            await Task.Delay(3000);
            IsBusy = false;
            NavigationManager.NavigateTo("/", false, true);
        }

        private void ShowErrorModal(string message)
        {
            modalMessage = message;
            showErrorModal = true;
            StateHasChanged();
        }

        private void CloseModal()
        {
            showErrorModal = false;
            modalMessage = string.Empty;
            StateHasChanged();
        }

        private void ClearOTPFields()
        {
            otp1 = otp2 = otp3 = otp4 = otp5 = otp6 = string.Empty;
        }

        private async Task HandleBackspace(KeyboardEventArgs e, ElementReference current, ElementReference? previous)
        {
            if (e.Key == "Backspace")
            {
                if (string.IsNullOrEmpty(await JS.InvokeAsync<string>("otp.getValue", current)))
                {
                    if (previous != null)
                    {
                        await JS.InvokeVoidAsync("otp.handleBackspace", current, previous);
                    }
                    else
                    {
                        await JS.InvokeVoidAsync("otp.clearAll", new[] { otp1Ref, otp2Ref, otp3Ref, otp4Ref, otp5Ref, otp6Ref });
                    }
                }
            }
        }

        private bool IsPasswordValid(string password, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(password) || password.Length < 7)
            {
                error = "Password must be at least 7 characters long.";
                return false;
            }

            if (!password.All(char.IsLetterOrDigit))
            {
                error = "Password can only contain letters and numbers (no spaces or special characters).";
                return false;
            }

            return true;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    InvokeAsync(StateHasChanged);
                }
            }
        }
    }
}
