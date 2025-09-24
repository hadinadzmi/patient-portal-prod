using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceRequestAppointmentRequest : ServiceBaseWebRequest
    {
        public string TenantId { get; set; }
        public string SpecialtyId { get; set; }
        public string DoctorId { get; set; }
        public string AppointmentDateStr { get; set; }
        public DateOnly AppointmentDate
        {
            get
            {
                DateOnly d;
                if (DateOnly.TryParseExact(AppointmentDateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out d))
                {
                    return d;
                }
                return DateOnly.MinValue;
            }
        }
        public string AppointmentTimeStr { get; set; }
        public TimeOnly AppointmentTime
        {
            get
            {
                TimeOnly t;
                if (TimeOnly.TryParseExact(AppointmentTimeStr, " HH:mm", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out t))
                {
                    return t;
                }
                return TimeOnly.MinValue;

            }
        }
        public string OnBehalf { get; set; }
        public string OnBehalfName { get; set; }
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public string PatientDOBStr { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string AdditionalMessage { get; set; }
        //before confirm to submit appointment, OTP number will be send to their provided phone number and validate the OTP number
        public string OTPNumber { get; set; }
    }
    public class ServiceRequestAppointmentRequestResponse : ServiceBaseWebResponse
    {
        //we should get response from EMR with AppointmentId and QR Code id if appointment is successfully created
        public string AppointmentId { get; set; }
        public string QRCodeId { get; set; }
    }
}
