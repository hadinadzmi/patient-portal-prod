using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Name = "Patient", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class Patient : DomainBaseModel
    {

        #region Constants

        public static readonly string PKID = "PkId";
        public static readonly string PATIENTID = "PatientId";
        public static readonly string CUSTOMERID = "CustomerId";
        public static readonly string TENANTID = "TenantId";
        public static readonly string RECORDSTATE = "RecordState";
        public static readonly string ROWVERSION = "RowVersion";
        public static readonly string DOBAPPROX = "DoBApprox";
        public static readonly string TITLE = "Title";
        public static readonly string SEX = "Sex";
        public static readonly string DATEOFBIRTH = "DateOfBirth";
        public static readonly string VIP = "Vip";
        public static readonly string PHOTOID = "PhotoId";
        public static readonly string IDENTITYDOCUMENTNUMBERTYPE = "IdentityDocumentNumberType";
        public static readonly string SALUTATION = "Salutation";
        public static readonly string CITIZENSHIP = "Citizenship";
        public static readonly string MARITALSTATUS = "MaritalStatus";
        public static readonly string RELIGION = "Religion";
        public static readonly string BLOODGROUP = "BloodGroup";
        public static readonly string RACE = "Race";
        public static readonly string LANGUAGE = "Language";
        public static readonly string SOCIALSECURITYNUMBER = "SocialSecurityNumber";
        public static readonly string MAIDENNAME = "MaidenName";
        public static readonly string PHONENUMBER = "PhoneNumber";
        public static readonly string MOBILENUMBER = "MobileNumber";
        public static readonly string MIDDLENAME = "MiddleName";
        public static readonly string FIRSTNAME = "FirstName";
        public static readonly string LASTNAME = "LastName";
        public static readonly string EMAIL = "Email";
        public static readonly string ADDRESSSTREET = "AddressStreet";
        public static readonly string PLACEOFBIRTH = "PlaceOfBirth";
        public static readonly string ADDITIONALINFORMATION = "AdditionalInformation";
        public static readonly string IDENTITYDOCUMENTNUMBER = "IdentityDocumentNumber";
        public static readonly string VISIBLEID = "VisibleId";
        public static readonly string FAMILYDOCTORID = "FamilyDoctorId";
        public static readonly string ADDRESSCITY = "AddressCity";
        public static readonly string ADDRESSZIPCODE = "AddressZipCode";
        public static readonly string ADDRESSCOUNTRYCODE = "AddressCountryCode";
        public static readonly string AREACODE = "AreaCode";
        public static readonly string APPOINTMENTREMINDER = "AppointmentReminder";
        public static readonly string PROVINCEID = "ProvinceId";
        public static readonly string DISTRICTID = "DistrictId";
        public static readonly string TOWNSHIPID = "TownshipId";
        public static readonly string ADDADDRESSNO = "AddAddressNo";
        public static readonly string ADDADDRESSSTREET = "AddAddressStreet";
        public static readonly string EXTERNALREFERENCEID = "ExternalReferenceId";
        public static readonly string DECEASEDON = "DeceasedOn";
        public static readonly string ISBLACKLISTED = "IsBlacklisted";
        public static readonly string NICKNAME = "NickName";
        public static readonly string ISEMPLOYEE = "IsEmployee";

        #endregion


        #region Constructor

        public Patient()
        {

        }

        #endregion


        #region Primitive Properties

        private long _pkId;
        
        [DataMember]
        public long PkId
        {
            get
            {

                return _pkId;
            }

            set
            {
                if (_pkId == value)
                {
                    return;
                }

                _pkId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(PKID);
#endif
            }

        }

        private System.Guid _patientId;
        
        [DataMember]
        public System.Guid PatientId
        {
            get
            {

                return _patientId;
            }

            set
            {
                if (_patientId == value)
                {
                    return;
                }

                _patientId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(PATIENTID);
#endif
            }

        }

        private byte _recordState;
        
        [DataMember]
        public byte RecordState
        {
            get
            {

                return _recordState;
            }

            set
            {
                if (_recordState == value)
                {
                    return;
                }

                _recordState = value;

#if SILVERLIGHT
    			 OnPropertyChanged(RECORDSTATE);
#endif
            }

        }

        private byte[] _rowVersion;
        
        [DataMember]
        public byte[] RowVersion
        {
            get
            {

                return _rowVersion;
            }

            set
            {
                if (_rowVersion == value)
                {
                    return;
                }

                _rowVersion = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ROWVERSION);
#endif
            }

        }

        private bool _doBApprox;
        
        [DataMember]
        public bool DoBApprox
        {
            get
            {

                return _doBApprox;
            }

            set
            {
                if (_doBApprox == value)
                {
                    return;
                }

                _doBApprox = value;

#if SILVERLIGHT
    			 OnPropertyChanged(DOBAPPROX);
#endif
            }

        }

        private Nullable<int> _title;
        
        [DataMember]
        public Nullable<int> Title
        {
            get
            {

                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                _title = value;

#if SILVERLIGHT
    			 OnPropertyChanged(TITLE);
#endif
            }

        }

        private Nullable<int> _sex;
        
        [DataMember]
        public Nullable<int> Sex
        {
            get
            {

                return _sex;
            }

            set
            {
                if (_sex == value)
                {
                    return;
                }

                _sex = value;

#if SILVERLIGHT
    			 OnPropertyChanged(SEX);
#endif
            }

        }

        private Nullable<System.DateTime> _dateOfBirth;
        
        [DataMember]
        public Nullable<System.DateTime> DateOfBirth
        {
            get
            {

                return _dateOfBirth;
            }

            set
            {
                if (_dateOfBirth == value)
                {
                    return;
                }

                _dateOfBirth = value;

#if SILVERLIGHT
    			 OnPropertyChanged(DATEOFBIRTH);
#endif
            }

        }

        private Nullable<bool> _vip;
        
        [DataMember]
        public Nullable<bool> Vip
        {
            get
            {

                return _vip;
            }

            set
            {
                if (_vip == value)
                {
                    return;
                }

                _vip = value;

#if SILVERLIGHT
    			 OnPropertyChanged(VIP);
#endif
            }

        }

        private Nullable<System.Guid> _photoId;
        
        [DataMember]
        public Nullable<System.Guid> PhotoId
        {
            get
            {

                return _photoId;
            }

            set
            {
                if (_photoId == value)
                {
                    return;
                }

                _photoId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(PHOTOID);
#endif
            }

        }

        private Nullable<int> _identityDocumentNumberType;
        
        [DataMember]
        public Nullable<int> IdentityDocumentNumberType
        {
            get
            {

                return _identityDocumentNumberType;
            }

            set
            {
                if (_identityDocumentNumberType == value)
                {
                    return;
                }

                _identityDocumentNumberType = value;

#if SILVERLIGHT
    			 OnPropertyChanged(IDENTITYDOCUMENTNUMBERTYPE);
#endif
            }

        }

        private Nullable<int> _salutation;
        
        [DataMember]
        public Nullable<int> Salutation
        {
            get
            {

                return _salutation;
            }

            set
            {
                if (_salutation == value)
                {
                    return;
                }

                _salutation = value;

#if SILVERLIGHT
    			 OnPropertyChanged(SALUTATION);
#endif
            }

        }

        private Nullable<int> _citizenship;
        
        [DataMember]
        public Nullable<int> Citizenship
        {
            get
            {

                return _citizenship;
            }

            set
            {
                if (_citizenship == value)
                {
                    return;
                }

                _citizenship = value;

#if SILVERLIGHT
    			 OnPropertyChanged(CITIZENSHIP);
#endif
            }

        }

        private Nullable<int> _maritalStatus;
        
        [DataMember]
        public Nullable<int> MaritalStatus
        {
            get
            {

                return _maritalStatus;
            }

            set
            {
                if (_maritalStatus == value)
                {
                    return;
                }

                _maritalStatus = value;

#if SILVERLIGHT
    			 OnPropertyChanged(MARITALSTATUS);
#endif
            }

        }

        private Nullable<int> _religion;
        
        [DataMember]
        public Nullable<int> Religion
        {
            get
            {

                return _religion;
            }

            set
            {
                if (_religion == value)
                {
                    return;
                }

                _religion = value;

#if SILVERLIGHT
    			 OnPropertyChanged(RELIGION);
#endif
            }

        }

        private Nullable<int> _bloodGroup;
        
        [DataMember]
        public Nullable<int> BloodGroup
        {
            get
            {

                return _bloodGroup;
            }

            set
            {
                if (_bloodGroup == value)
                {
                    return;
                }

                _bloodGroup = value;

#if SILVERLIGHT
    			 OnPropertyChanged(BLOODGROUP);
#endif
            }

        }

        private Nullable<int> _race;
        
        [DataMember]
        public Nullable<int> Race
        {
            get
            {

                return _race;
            }

            set
            {
                if (_race == value)
                {
                    return;
                }

                _race = value;

#if SILVERLIGHT
    			 OnPropertyChanged(RACE);
#endif
            }

        }

        private Nullable<int> _language;
        
        [DataMember]
        public Nullable<int> Language
        {
            get
            {

                return _language;
            }

            set
            {
                if (_language == value)
                {
                    return;
                }

                _language = value;

#if SILVERLIGHT
    			 OnPropertyChanged(LANGUAGE);
#endif
            }

        }

        private string _socialSecurityNumber;
        
        [DataMember]
        public string SocialSecurityNumber
        {
            get
            {

                return _socialSecurityNumber;
            }

            set
            {
                if (_socialSecurityNumber == value)
                {
                    return;
                }

                _socialSecurityNumber = value;

#if SILVERLIGHT
    			 OnPropertyChanged(SOCIALSECURITYNUMBER);
#endif
            }

        }

        private string _maidenName;
        
        [DataMember]
        public string MaidenName
        {
            get
            {

                return _maidenName;
            }

            set
            {
                if (_maidenName == value)
                {
                    return;
                }

                _maidenName = value;

#if SILVERLIGHT
    			 OnPropertyChanged(MAIDENNAME);
#endif
            }

        }

        private string _phoneNumber;
        
        [DataMember]
        public string PhoneNumber
        {
            get
            {

                return _phoneNumber;
            }

            set
            {
                if (_phoneNumber == value)
                {
                    return;
                }

                _phoneNumber = value;

#if SILVERLIGHT
    			 OnPropertyChanged(PHONENUMBER);
#endif
            }

        }

        private string _mobileNumber;
        
        [DataMember]
        public string MobileNumber
        {
            get
            {

                return _mobileNumber;
            }

            set
            {
                if (_mobileNumber == value)
                {
                    return;
                }

                _mobileNumber = value;

#if SILVERLIGHT
    			 OnPropertyChanged(MOBILENUMBER);
#endif
            }

        }

        private string _middleName;
        
        [DataMember]
        public string MiddleName
        {
            get
            {

                return _middleName;
            }

            set
            {
                if (_middleName == value)
                {
                    return;
                }

                _middleName = value;

#if SILVERLIGHT
    			 OnPropertyChanged(MIDDLENAME);
#endif
            }

        }

        private string _firstName;
        
        [DataMember]
        public string FirstName
        {
            get
            {

                return _firstName;
            }

            set
            {
                if (_firstName == value)
                {
                    return;
                }

                _firstName = value;

#if SILVERLIGHT
    			 OnPropertyChanged(FIRSTNAME);
#endif
            }

        }

        private string _lastName;
        
        [DataMember]
        public string LastName
        {
            get
            {

                return _lastName;
            }

            set
            {
                if (_lastName == value)
                {
                    return;
                }

                _lastName = value;

#if SILVERLIGHT
    			 OnPropertyChanged(LASTNAME);
#endif
            }

        }

        private string _email;
        
        [DataMember]
        public string Email
        {
            get
            {

                return _email;
            }

            set
            {
                if (_email == value)
                {
                    return;
                }

                _email = value;

#if SILVERLIGHT
    			 OnPropertyChanged(EMAIL);
#endif
            }

        }

        private string _addressStreet;
        
        [DataMember]
        public string AddressStreet
        {
            get
            {

                return _addressStreet;
            }

            set
            {
                if (_addressStreet == value)
                {
                    return;
                }

                _addressStreet = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDRESSSTREET);
#endif
            }

        }

        private string _placeOfBirth;
        
        [DataMember]
        public string PlaceOfBirth
        {
            get
            {

                return _placeOfBirth;
            }

            set
            {
                if (_placeOfBirth == value)
                {
                    return;
                }

                _placeOfBirth = value;

#if SILVERLIGHT
    			 OnPropertyChanged(PLACEOFBIRTH);
#endif
            }

        }

        private string _additionalInformation;
        
        [DataMember]
        public string AdditionalInformation
        {
            get
            {

                return _additionalInformation;
            }

            set
            {
                if (_additionalInformation == value)
                {
                    return;
                }

                _additionalInformation = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDITIONALINFORMATION);
#endif
            }

        }

        private string _identityDocumentNumber;
        
        [DataMember]
        public string IdentityDocumentNumber
        {
            get
            {

                return _identityDocumentNumber;
            }

            set
            {
                if (_identityDocumentNumber == value)
                {
                    return;
                }

                _identityDocumentNumber = value;

#if SILVERLIGHT
    			 OnPropertyChanged(IDENTITYDOCUMENTNUMBER);
#endif
            }

        }

        private string _visibleId;
        
        [DataMember]
        public string VisibleId
        {
            get
            {

                return _visibleId;
            }

            set
            {
                if (_visibleId == value)
                {
                    return;
                }

                _visibleId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(VISIBLEID);
#endif
            }

        }

        private Nullable<System.Guid> _familyDoctorId;
        
        [DataMember]
        public Nullable<System.Guid> FamilyDoctorId
        {
            get
            {

                return _familyDoctorId;
            }

            set
            {
                if (_familyDoctorId == value)
                {
                    return;
                }

                _familyDoctorId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(FAMILYDOCTORID);
#endif
            }

        }

        private string _addressCity;
        
        [DataMember]
        public string AddressCity
        {
            get
            {

                return _addressCity;
            }

            set
            {
                if (_addressCity == value)
                {
                    return;
                }

                _addressCity = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDRESSCITY);
#endif
            }

        }

        private string _addressZipCode;
        
        [DataMember]
        public string AddressZipCode
        {
            get
            {

                return _addressZipCode;
            }

            set
            {
                if (_addressZipCode == value)
                {
                    return;
                }

                _addressZipCode = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDRESSZIPCODE);
#endif
            }

        }

        private string _addressCountryCode;
        
        [DataMember]
        public string AddressCountryCode
        {
            get
            {

                return _addressCountryCode;
            }

            set
            {
                if (_addressCountryCode == value)
                {
                    return;
                }

                _addressCountryCode = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDRESSCOUNTRYCODE);
#endif
            }

        }

        private Nullable<int> _areaCode;
        
        [DataMember]
        public Nullable<int> AreaCode
        {
            get
            {

                return _areaCode;
            }

            set
            {
                if (_areaCode == value)
                {
                    return;
                }

                _areaCode = value;

#if SILVERLIGHT
    			 OnPropertyChanged(AREACODE);
#endif
            }

        }

        private Nullable<int> _appointmentReminder;
        
        [DataMember]
        public Nullable<int> AppointmentReminder
        {
            get
            {

                return _appointmentReminder;
            }

            set
            {
                if (_appointmentReminder == value)
                {
                    return;
                }

                _appointmentReminder = value;

#if SILVERLIGHT
    			 OnPropertyChanged(APPOINTMENTREMINDER);
#endif
            }

        }

        private Nullable<System.Guid> _provinceId;
        
        [DataMember]
        public Nullable<System.Guid> ProvinceId
        {
            get
            {

                return _provinceId;
            }

            set
            {
                if (_provinceId == value)
                {
                    return;
                }

                _provinceId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(PROVINCEID);
#endif
            }

        }

        private Nullable<System.Guid> _districtId;
        
        [DataMember]
        public Nullable<System.Guid> DistrictId
        {
            get
            {

                return _districtId;
            }

            set
            {
                if (_districtId == value)
                {
                    return;
                }

                _districtId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(DISTRICTID);
#endif
            }

        }

        private Nullable<System.Guid> _townshipId;
        
        [DataMember]
        public Nullable<System.Guid> TownshipId
        {
            get
            {

                return _townshipId;
            }

            set
            {
                if (_townshipId == value)
                {
                    return;
                }

                _townshipId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(TOWNSHIPID);
#endif
            }

        }

        private string _addAddressNo;
        
        [DataMember]
        public string AddAddressNo
        {
            get
            {

                return _addAddressNo;
            }

            set
            {
                if (_addAddressNo == value)
                {
                    return;
                }

                _addAddressNo = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDADDRESSNO);
#endif
            }

        }

        private string _addAddressStreet;
        
        [DataMember]
        public string AddAddressStreet
        {
            get
            {

                return _addAddressStreet;
            }

            set
            {
                if (_addAddressStreet == value)
                {
                    return;
                }

                _addAddressStreet = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDADDRESSSTREET);
#endif
            }

        }

        private string _externalReferenceId;
        
        [DataMember]
        public string ExternalReferenceId
        {
            get
            {

                return _externalReferenceId;
            }

            set
            {
                if (_externalReferenceId == value)
                {
                    return;
                }

                _externalReferenceId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(EXTERNALREFERENCEID);
#endif
            }

        }

        private Nullable<System.DateTime> _deceasedOn;
        
        [DataMember]
        public Nullable<System.DateTime> DeceasedOn
        {
            get
            {

                return _deceasedOn;
            }

            set
            {
                if (_deceasedOn == value)
                {
                    return;
                }

                _deceasedOn = value;

#if SILVERLIGHT
    			 OnPropertyChanged(DECEASEDON);
#endif
            }

        }

        private bool _isBlacklisted;
        
        [DataMember]
        public bool IsBlacklisted
        {
            get
            {

                return _isBlacklisted;
            }

            set
            {
                if (_isBlacklisted == value)
                {
                    return;
                }

                _isBlacklisted = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ISBLACKLISTED);
#endif
            }

        }

        private string _nickName;
        
        [DataMember]
        public string NickName
        {
            get
            {

                return _nickName;
            }

            set
            {
                if (_nickName == value)
                {
                    return;
                }

                _nickName = value;

#if SILVERLIGHT
    			 OnPropertyChanged(NICKNAME);
#endif
            }

        }

        private bool _isEmployee;
        
        [DataMember]
        public bool IsEmployee
        {
            get
            {

                return _isEmployee;
            }

            set
            {
                if (_isEmployee == value)
                {
                    return;
                }

                _isEmployee = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ISEMPLOYEE);
#endif
            }

        }

        #endregion


    }
}
