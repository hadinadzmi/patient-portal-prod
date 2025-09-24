using System;
using System.ComponentModel.DataAnnotations;

namespace Patient_Portal.Pages
{
    public class AppointmentFormModel
    {
        //[Required(ErrorMessage = "Patient's full name is required.")]
        public string PatientName { get; set; }

        //[Required(ErrorMessage = "NRIC/Passport number is required.")]
        public string PatientNricPassport { get; set; }

        //[Required(ErrorMessage = "Date of birth is required.")]
        public string PatientDob { get; set; }

        //[Required(ErrorMessage = "Country code is required.")]
        public int CountryCode { get; set; }

        //[Required(ErrorMessage = "Phone number is required.")]
        public string PatientMobileNumber { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; }
        public string AdditionalMessage { get; set; }
    }
}
