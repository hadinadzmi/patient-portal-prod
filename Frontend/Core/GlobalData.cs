using Blazored.LocalStorage;
using Microsoft.VisualBasic.CompilerServices;
using Patient_Portal.Shared;
//using Patient_Portal.Utils;
using Telerik.Blazor.Components;

namespace Patient_Portal.Core
{
    public class GlobalData //tempat dia store data global based on Response yg dia dpt dari server
    {
        public const string KEY_AUTH = "auth";
        public static EventHandler OnRefresh;
        public static string UserKey { get; private set; }
        public static Guid PatientId { get; private set; } //pakai
        public static string PatientNRIC { get; private set; } // pakai
        public static string PatientName { get; private set; }// pakai
        public static string PatientMobileNumber { get; private set; } // pakai
        public static string PatientDOB { get; private set; } // pakai
        public static bool IsConfirmationCodeEntered { get; private set; }
        public static string ServiceUri { get; set; }
        public static string ServiceProtocol { get; set; }
        public static string ServicePort { get; set; }
        public static string TenantKey { get; set; }
        public static string Language { get; set; }
        public static string PatientPortalUserName { get; set; }
        public static bool OnlyShowPatientFirstName { get; set; }
        public static bool TestMode { get; set; }
        public static string MeedioBaseUrl { get; set; }
        public static bool IsMeedioOpenedExternal { get; set; }
        public static string PwEncStr { get; set; }
        public static void SetGlobalData(IConfiguration config)
        {
            ServiceUri = config[nameof(ServiceUri)];
            ServiceProtocol = config[nameof(ServiceProtocol)];
            ServicePort = config[nameof(ServicePort)];
            TenantKey = config[nameof(TenantKey)];
            Language = config[nameof(Language)];
            PatientPortalUserName = config[nameof(PatientPortalUserName)];
            OnlyShowPatientFirstName = bool.Parse(config[nameof(OnlyShowPatientFirstName)]);
            PwEncStr = config[nameof(PwEncStr)];
            var testModeStr = config[nameof(TestMode)];
            MeedioBaseUrl = config["MeedioBaseUrl"];
            if (!String.IsNullOrWhiteSpace(testModeStr) && bool.TryParse(testModeStr, out var testMode))
                TestMode = testMode;

            var isMeedioExtStr = config["OpenMeedioExternal"];
            if (isMeedioExtStr != null && bool.TryParse(isMeedioExtStr, out var tmpBool))
            {
                IsMeedioOpenedExternal = tmpBool;
            }
            var availableServicesStr = config["ServiceIdTextPairs"];
            SetAvailableServices(availableServicesStr);
            //AppointmentUtils.SetConfig(config);
            //WorkflowMessageUtils.SetConfig(config);
            //CaseComUtils.SetConfig(config);
        }
        private static void SetAvailableServices(string availableServiceStr)
        {
            //AvailableServices = new List<LocalServiceEntryForAppointment>();
            if (String.IsNullOrWhiteSpace(availableServiceStr))
            {
                return;
            }

            var splt = availableServiceStr.Split("||");
            foreach (var entry in splt)
            {
                var innerSplt = entry.Split('|');
                //if (Guid.TryParse(innerSplt[0], out var serviceId) && innerSplt.Length > 1)
                //{
                //    AvailableServices.Add(new LocalServiceEntryForAppointment()
                //        {ServiceId = serviceId, Text = innerSplt[1]});
                //}
            }
        }
        public static async Task SetUserData(ILocalStorageService localStorage, Guid patientID, string patientNRIC, string patientName, string patientMobileNumber, string patientDOB)
        {
            PatientId = patientID;
            PatientNRIC = patientNRIC;
            PatientName = patientName;
            PatientMobileNumber = patientMobileNumber;
            PatientDOB = patientDOB;

            if (localStorage != null)
            {
                var authData = new AuthData(DateTime.Now, patientID, patientNRIC, patientName, patientMobileNumber, patientDOB);
                await localStorage.SetItemAsync(KEY_AUTH, authData);
            }
        }
        public static async Task ResetUserData(ILocalStorageService localStorage)
        {
            await SetUserData(localStorage, Guid.Empty, null, null, null, null);
            if (localStorage != null)
                await localStorage.RemoveItemAsync(KEY_AUTH);
        }
        private static bool _userDataRestored;
        /// <summary>
        /// Should only happen on "first run" -> check if "cookie" there, and set
        /// </summary>
        /// <param name="localStorageSync"></param>
        public static void RestoreUserData(ISyncLocalStorageService localStorageSync, out bool refresh)
        {
            refresh = false;
            if (_userDataRestored)
                return;

            refresh = true;
            _userDataRestored = true;
            var cookie = localStorageSync.GetItem<AuthData>(GlobalData.KEY_AUTH);
            if (cookie != null)
            {
                SetUserData(null, cookie.PatientID, cookie.PatientNRIC, cookie.PatientName, cookie.PatientMobileNumber, cookie.PatientDOB);
            }
        }
    }
}
