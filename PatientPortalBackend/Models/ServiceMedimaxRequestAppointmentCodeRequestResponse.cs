namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxRequestAppointmentCodeRequest : ServiceBaseWebRequest
    {
        public string PatientName { get; set; }
        public string PatientNRIC { get; set; }
        public string PatientPhoneNum { get; set; }
        public string RequestType { get; set; }
    }

    public class ServiceMedimaxRequestAppointmentCodeResponse : ServiceBaseWebResponse
    {
        //nothing special here
    }
}
