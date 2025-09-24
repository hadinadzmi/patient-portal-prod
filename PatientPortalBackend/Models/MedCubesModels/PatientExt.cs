using System.Runtime.Serialization;
using System;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.Models.WrapperServicesExt")]
    public class PatientExt
    {
        #region Primitive Properties

        [DataMember(Order = 1)]
        public System.Guid PatientId { get; set; }

        //[DataMember]
        //public byte RecordState { get; set; }


        [DataMember(Order = 2)]
        public Nullable<int> Title { get; set; }


        [DataMember(Order = 3)]
        public Nullable<int> Sex { get; set; }



        [DataMember(Order = 4)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }


        [DataMember(Order = 5)]
        public Nullable<int> IdentityDocumentNumberType { get; set; }

        [DataMember(Order = 6)]
        public string IdentityDocumentNumber { get; set; }


        [DataMember(Order = 7)]
        public Nullable<int> Salutation { get; set; }


        [DataMember(Order = 8)]
        public Nullable<int> Citizenship { get; set; }


        [DataMember(Order = 9)]
        public Nullable<int> MaritalStatus { get; set; }


        [DataMember(Order = 10)]
        public Nullable<int> Religion { get; set; }

        [DataMember(Order = 11)]
        public Nullable<int> BloodGroup { get; set; }

        [DataMember(Order = 12)]
        public Nullable<int> Race { get; set; }

        [DataMember(Order = 13)]
        public Nullable<int> Language { get; set; }

        [DataMember(Order = 14)]
        public string SocialSecurityNumber { get; set; }

        [DataMember(Order = 15)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 16)]
        public string MobileNumber { get; set; }

        [DataMember(Order = 17)]
        public string Email { get; set; }

        [DataMember(Order = 18)]
        public string FirstName { get; set; }

        [DataMember(Order = 19)]
        public string MiddleName { get; set; }

        [DataMember(Order = 20)]
        public string LastName { get; set; }

        [DataMember(Order = 21)]
        public string PlaceOfBirth { get; set; }

        [DataMember(Order = 22)]
        public string AdditionalInformation { get; set; }

        [DataMember(Order = 23)]
        public string VisibleId { get; set; }

        [DataMember(Order = 24)]
        public string AddressStreet { get; set; }

        [DataMember(Order = 25)]
        public string AddressCity { get; set; }

        [DataMember(Order = 26)]
        public string AddressZipCode { get; set; }

        [DataMember(Order = 27)]
        public string AddressCountryCode { get; set; }

        #endregion
    }
}
