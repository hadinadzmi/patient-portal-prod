using Patient_Portal.Core;

namespace Patient_Portal.WebApi
{
    public static class ServiceUris
    {
        // Appointments
        public static Uri GetPatientAppointmentUri => GetFullUri("/api/Appointments/GetPatientAppointments");
        public static Uri CreatePatientAppointmentUri => GetFullUri("/api/Appointments/CreatePatientAppointment");
        public static Uri CreateRequestPatientAppointmentUri => GetFullUri("/api/Appointments/CreateRequestPatientAppointment");
        public static Uri GetTenantDetailsUri => GetFullUri("/api/Appointments/GetResourceList");
        public static Uri GetDepartmentDetailsAndServiceUnitsUri => GetFullUri("/api/Appointments/GetDepartmentDetailsAndServiceUnits");
        public static Uri GetUsersIdByTenantUri => GetFullUri("/api/Appointments/GetUsersIdByTenantId");
        public static Uri GetUsersDetailsByUserIdUri => GetFullUri("/api/Appointments/GetUserNameByUserId");
        public static Uri GetUserDetailsByUserIdListUri => GetFullUri("/api/Appointments/GetUserDetailsByUserIdList");
        public static Uri GetResourceDetailsByUserIdUri => GetFullUri("/api/Appointments/GetResourceDetailList");
        public static Uri GetAppointmentDetailsByPatientCalendarEntryIdUri => GetFullUri("/api/Appointments/GetPatientCalendarEntryIdList");
        public static Uri GetAppointmentDetailsUri => GetFullUri("/api/Appointments/GetAppointmentDetailsByPatientCalendarEntryId");
        public static Uri GetUserResourceTimeListByResourceIdUri => GetFullUri("/api/Appointments/GetUserResourceTimeListByResourceId");
        public static Uri CancelPatientAppointmentUri => GetFullUri("/api/Appointments/CancelPatientAppointment");
        public static Uri UpdatePatientAppointmentUri => GetFullUri("/api/Appointments/UpdatePatientAppointment");
        public static Uri GetPopupDetailsListUri => GetFullUri("/api/Appointments/GetPopupDetailsList");


        // MedimaxAllergy
        public static Uri GetPatientAllergiesUri => GetFullUri("/api/MedimaxAllergy/GetPatientAllergies");

        // MedimaxAuthentication
        public static Uri GetLoginDetailsUri => GetFullUri("/api/MedimaxAuthentication/GetLoginDetails"); //to get login details
        public static Uri GetConfirmationCodeUri => GetFullUri("/api/MedimaxAuthentication/GetConfirmationCode");
        public static Uri VerifyConfirmationCodeUri => GetFullUri("/api/MedimaxAuthentication/VerifyConfirmationCode");
        public static Uri SetPasswordAfterCodeUri => GetFullUri("/api/MedimaxAuthentication/SetPasswordAfterCode");

        // MedimaxDocument
        public static Uri GetPatientDocumentsUri => GetFullUri("/api/MedimaxDocument/GetPatientDocuments");
        public static Uri DownloadPatientDocumentsUri => GetFullUri("/api/MedimaxDocument/DownloadPatientDocument");

        private static Uri GetFullUri(string wsPart)
        {
            return new Uri($"{GlobalData.ServiceProtocol}://{GlobalData.ServiceUri}:{GlobalData.ServicePort}{wsPart}");
        }
    }
}
