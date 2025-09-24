using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Attention!!!
    /// Place new functionality into separate partial class as this class-file will be recreated
    /// if tt procedure is executed again (your modifications would be lost)!
    /// </summary>
    [DataContract(Name = "User", Namespace = "MedCubes.Framework.Models")]
    public partial class User : DomainBaseModel
    {
        #region Constants
        public static readonly string USERID = "UserId";
        public static readonly string USERNAME = "UserName";
        public static readonly string RECORDSTATE = "RecordState";
        public static readonly string ROWVERSION = "RowVersion";
        public static readonly string ISACTIVE = "IsActive";
        public static readonly string FIRSTNAME = "FirstName";
        public static readonly string MIDDLENAME = "MiddleName";
        public static readonly string LASTNAME = "LastName";
        public static readonly string SEX = "Sex";
        public static readonly string TITLE = "Title";
        public static readonly string EMAIL = "EMail";
        public static readonly string PHONE = "Phone";
        public static readonly string ADDITIONALINFORMATION = "AdditionalInformation";
        public static readonly string PASSWORD = "Password";
        public static readonly string USERMUSTCHANGEPASSWORD = "UserMustChangePassword";
        public static readonly string PHOTOID = "PhotoId";
        public static readonly string USERSTATE = "UserState";
        public static readonly string VALIDFROM = "ValidFrom";
        public static readonly string VALIDTO = "ValidTo";
        public static readonly string USERQUALIFICATIONS = "UserQualifications";
        public static readonly string CULTURE = "Culture";
        public static readonly string USERKEY = "UserKey";
        public static readonly string ADDITIONALUSERKEY = "AdditionalUserKey";
        public static readonly string PASSWORDCHANGEDDATE = "PasswordChangedDate";
        public static readonly string TEACHINGLEVEL = "TeachingLevel";
        public static readonly string DECIMALMARK = "DecimalMark";
        public static readonly string SPECIALITY = "Speciality";
        public static readonly string SERVICEBOOKINGQUALIFICATION = "ServiceBookingQualification";
        public static readonly string ALTERNATEDIGNITYUSERID = "AlternateDignityUserId";
        public static readonly string ZSRNUMBER = "ZsrNumber";
        public static readonly string GLNNUMBER = "GlnNumber";
        public static readonly string SALUTATION = "Salutation";
        public static readonly string BOOKINGDATEFROM = "BookingDateFrom";
        public static readonly string BOOKINGDATETO = "BookingDateTo";

        #endregion


        #region Constructor

        public User()
        {
        }

        #endregion


        #region Primitive Properties

        private long _userId;
        [DataMember]
        public long UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                if (_userId == value) return;
                _userId = value;
#if SILVERLIGHT
    		   OnPropertyChanged(USERID);
#endif
            }
        }

        private string _userName;
        
        [DataMember]
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName == value) return;
                _userName = value;
#if SILVERLIGHT
    		   OnPropertyChanged(USERNAME);
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
                if (_recordState == value) return;
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
                if (_rowVersion == value) return;
                _rowVersion = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ROWVERSION);
#endif
            }
        }

        private bool _isActive;
        
        [DataMember]
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if (_isActive == value) return;
                _isActive = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ISACTIVE);
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
                if (_firstName == value) return;
                _firstName = value;
#if SILVERLIGHT
    		   OnPropertyChanged(FIRSTNAME);
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
                if (_middleName == value) return;
                _middleName = value;
#if SILVERLIGHT
    		   OnPropertyChanged(MIDDLENAME);
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
                if (_lastName == value) return;
                _lastName = value;
#if SILVERLIGHT
    		   OnPropertyChanged(LASTNAME);
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
                if (_sex == value) return;
                _sex = value;
#if SILVERLIGHT
    		   OnPropertyChanged(SEX);
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
                if (_title == value) return;
                _title = value;
#if SILVERLIGHT
    		   OnPropertyChanged(TITLE);
#endif
            }
        }

        private string _eMail;
        
        [DataMember]
        public string EMail
        {
            get
            {
                return _eMail;
            }
            set
            {
                if (_eMail == value) return;
                _eMail = value;
#if SILVERLIGHT
    		   OnPropertyChanged(EMAIL);
#endif
            }
        }

        private string _phone;
        
        [DataMember]
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (_phone == value) return;
                _phone = value;
#if SILVERLIGHT
    		   OnPropertyChanged(PHONE);
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
                if (_additionalInformation == value) return;
                _additionalInformation = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ADDITIONALINFORMATION);
#endif
            }
        }

        private byte[] _password;
        
        [DataMember]
        public byte[] Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password == value) return;
                _password = value;
#if SILVERLIGHT
    		   OnPropertyChanged(PASSWORD);
#endif
            }
        }

        private Nullable<bool> _userMustChangePassword;
        
        [DataMember]
        public Nullable<bool> UserMustChangePassword
        {
            get
            {
                return _userMustChangePassword;
            }
            set
            {
                if (_userMustChangePassword == value) return;
                _userMustChangePassword = value;
#if SILVERLIGHT
    		   OnPropertyChanged(USERMUSTCHANGEPASSWORD);
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
                if (_photoId == value) return;
                _photoId = value;
#if SILVERLIGHT
    		   OnPropertyChanged(PHOTOID);
#endif
            }
        }

        private byte _userState;
        
        [DataMember]
        public byte UserState
        {
            get
            {
                return _userState;
            }
            set
            {
                if (_userState == value) return;
                _userState = value;
#if SILVERLIGHT
    		   OnPropertyChanged(USERSTATE);
#endif
            }
        }

        private System.DateTime _validFrom;
        
        [DataMember]
        public System.DateTime ValidFrom
        {
            get
            {
                return _validFrom;
            }
            set
            {
                if (_validFrom == value) return;
                _validFrom = value;
#if SILVERLIGHT
    		   OnPropertyChanged(VALIDFROM);
#endif
            }
        }

        private Nullable<System.DateTime> _validTo;
        
        [DataMember]
        public Nullable<System.DateTime> ValidTo
        {
            get
            {
                return _validTo;
            }
            set
            {
                if (_validTo == value) return;
                _validTo = value;
#if SILVERLIGHT
    		   OnPropertyChanged(VALIDTO);
#endif
            }
        }

        private string _userQualifications;
        
        [DataMember]
        public string UserQualifications
        {
            get
            {
                return _userQualifications;
            }
            set
            {
                if (_userQualifications == value) return;
                _userQualifications = value;
#if SILVERLIGHT
    		   OnPropertyChanged(USERQUALIFICATIONS);
#endif
            }
        }

        private Nullable<int> _culture;
        
        [DataMember]
        public Nullable<int> Culture
        {
            get
            {
                return _culture;
            }
            set
            {
                if (_culture == value) return;
                _culture = value;
#if SILVERLIGHT
    		   OnPropertyChanged(CULTURE);
#endif
            }
        }

        private string _userKey;
        
        [DataMember]
        public string UserKey
        {
            get
            {
                return _userKey;
            }
            set
            {
                if (_userKey == value) return;
                _userKey = value;
#if SILVERLIGHT
    		   OnPropertyChanged(USERKEY);
#endif
            }
        }

        private string _additionalUserKey;
        
        [DataMember]
        public string AdditionalUserKey
        {
            get
            {
                return _additionalUserKey;
            }
            set
            {
                if (_additionalUserKey == value) return;
                _additionalUserKey = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ADDITIONALUSERKEY);
#endif
            }
        }

        private Nullable<System.DateTime> _passwordChangedDate;
        
        [DataMember]
        public Nullable<System.DateTime> PasswordChangedDate
        {
            get
            {
                return _passwordChangedDate;
            }
            set
            {
                if (_passwordChangedDate == value) return;
                _passwordChangedDate = value;
#if SILVERLIGHT
    		   OnPropertyChanged(PASSWORDCHANGEDDATE);
#endif
            }
        }

        private Nullable<int> _teachingLevel;
        
        [DataMember]
        public Nullable<int> TeachingLevel
        {
            get
            {
                return _teachingLevel;
            }
            set
            {
                if (_teachingLevel == value) return;
                _teachingLevel = value;
#if SILVERLIGHT
    		    OnPropertyChanged(TEACHINGLEVEL);
#endif
            }
        }

        private string _decimalMark;
        
        [DataMember]
        public string DecimalMark
        {
            get
            {
                return _decimalMark;
            }
            set
            {
                if (_decimalMark == value) return;
                _decimalMark = value;
#if SILVERLIGHT
    		    OnPropertyChanged(DECIMALMARK);
#endif
            }
        }

        private Nullable<int> _speciality;
        
        [DataMember]
        public Nullable<int> Speciality
        {
            get
            {
                return _speciality;
            }
            set
            {
                if (_speciality == value) return;
                _speciality = value;
#if SILVERLIGHT
    		    OnPropertyChanged(SPECIALITY);
#endif
            }
        }

        private string _serviceBookingQualification;
        
        [DataMember]
        public string ServiceBookingQualification
        {
            get
            {
                return _serviceBookingQualification;
            }
            set
            {
                if (_serviceBookingQualification == value) return;
                _serviceBookingQualification = value;
#if SILVERLIGHT
    		    OnPropertyChanged(SERVICEBOOKINGQUALIFICATION);
#endif
            }
        }

        private Nullable<long> _alternateDignityUserId;
        
        [DataMember]
        public Nullable<long> AlternateDignityUserId
        {
            get
            {
                return _alternateDignityUserId;
            }
            set
            {
                if (_alternateDignityUserId == value) return;
                _alternateDignityUserId = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ALTERNATEDIGNITYUSERID);
#endif
            }
        }

        private string _glnNumber;

        [DataMember]
        public string GlnNumber
        {
            get
            {
                return _glnNumber;
            }
            set
            {
                if (_glnNumber == value)
                {
                    return;
                }

                _glnNumber = value;
#if SILVERLIGHT
    			 OnPropertyChanged(GLNNUMBER);
#endif
            }
        }

        private string _zsrNumber;

        [DataMember]
        public string ZsrNumber
        {
            get
            {
                return _zsrNumber;
            }
            set
            {
                if (_zsrNumber == value)
                {
                    return;
                }

                _zsrNumber = value;
#if SILVERLIGHT
    			 OnPropertyChanged(ZSRNUMBER);
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
                if (_salutation == value) return;
                _salutation = value;
#if SILVERLIGHT
    		   OnPropertyChanged(SALUTATION);
#endif
            }
        }

        private Nullable<System.DateTime> _bookingDateFrom;
        [DataMember]
        public Nullable<System.DateTime> BookingDateFrom
        {
            get
            {
                return _bookingDateFrom;
            }
            set
            {
                if (_bookingDateFrom == value) return;
                _bookingDateFrom = value;
#if SILVERLIGHT
    		   OnPropertyChanged(BOOKINGDATEFROM);
#endif
            }
        }

        private Nullable<System.DateTime> _bookingDateTo;
        [DataMember]
        public Nullable<System.DateTime> BookingDateTo
        {
            get
            {
                return _bookingDateTo;
            }
            set
            {
                if (_bookingDateTo == value) return;
                _bookingDateTo = value;
#if SILVERLIGHT
    		   OnPropertyChanged(BOOKINGDATETO);
#endif
            }
        }
        #endregion
    }


    /// <summary>
    /// DTO, e.g. for HL7, to get a small user object with the userCode as extension..
    /// </summary>
    [DataContract(Name = "UserDto", Namespace = "MedCubes.Framework.Models")]
    public partial class UserCodeDto
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public string UserCode { get; set; }

        [DataMember]
        public string UserLastName { get; set; }

        [DataMember]
        public string UserFirstName { get; set; }
    }

    /// <summary>
    /// Dto for transfering data over the wire.
    /// </summary>
    [DataContract(Name = "UserDto", Namespace = "MedCubes.Framework.Models")]
    public partial class UserDto
    {

        //[DataMember]	
        //public long UserId {get; set;}

        //[DataMember]	
        //public string UserName {get; set;}

        //[DataMember]	
        //public byte RecordState {get; set;}

        //[DataMember]	
        //public byte[] RowVersion {get; set;}

        //[DataMember]	
        //public bool IsActive {get; set;}

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        //[DataMember]	
        //public Nullable<int> Sex {get; set;}

        //[DataMember]	
        //public Nullable<int> Title {get; set;}

        [DataMember]
        public string EMail { get; set; }

        [DataMember]
        public string Phone { get; set; }

        //[DataMember]	
        //public string AdditionalInformation {get; set;}

        //[DataMember]	
        //public byte[] Password {get; set;}

        //[DataMember]	
        //public Nullable<bool> UserMustChangePassword {get; set;}

        //[DataMember]	
        //public Nullable<System.Guid> PhotoId {get; set;}

        //[DataMember]	
        //public byte UserState {get; set;}

        //[DataMember]	
        //public System.DateTime ValidFrom {get; set;}

        //[DataMember]	
        //public Nullable<System.DateTime> ValidTo {get; set;}

        //[DataMember]	
        //public string UserQualifications {get; set;}


        /// <summary>
        /// This method creates a new domainbasemodel and moves the values of the 
        /// matching properties from the current dto to the domainbasemodel.
        /// </summary>
        public User ToModel()
        {
            var model = new User();
            //model.UserId = UserId;
            //model.UserName = UserName;
            //model.RecordState = RecordState;
            //model.RowVersion = RowVersion;
            //model.IsActive = IsActive;
            model.FirstName = FirstName;
            model.MiddleName = MiddleName;
            model.LastName = LastName;
            //model.Sex = Sex;
            //model.Title = Title;
            model.EMail = EMail;
            model.Phone = Phone;
            //model.AdditionalInformation = AdditionalInformation;
            //model.Password = Password;
            //model.UserMustChangePassword = UserMustChangePassword;
            //model.PhotoId = PhotoId;
            //model.UserState = UserState;
            //model.ValidFrom = ValidFrom;
            //model.ValidTo = ValidTo;
            //model.UserQualifications = UserQualifications;

            return model;
        }
    }

    public partial class User
    {
        public override string GetHistoryKey()
        {
            return UserId.ToString();
        }


        /// <summary>
        /// This method creates a new dto and moves the values of the 
        /// matching properties from the current domainbasemodel to the dto.
        /// </summary>
        public UserDto ToDto()
        {
            var dto = new UserDto();
            //dto.UserId = UserId;
            //dto.UserName = UserName;
            //dto.RecordState = RecordState;
            //dto.RowVersion = RowVersion;
            //dto.IsActive = IsActive;
            dto.FirstName = FirstName;
            dto.MiddleName = MiddleName;
            dto.LastName = LastName;
            //dto.Sex = Sex;
            //dto.Title = Title;
            dto.EMail = EMail;
            dto.Phone = Phone;
            //dto.AdditionalInformation = AdditionalInformation;
            //dto.Password = Password;
            //dto.UserMustChangePassword = UserMustChangePassword;
            //dto.PhotoId = PhotoId;
            //dto.UserState = UserState;
            //dto.ValidFrom = ValidFrom;
            //dto.ValidTo = ValidTo;
            //dto.UserQualifications = UserQualifications;

            return dto;
        }

        private string _userCodeTenantOfUser;
        [DataMember]
        public string UserCodeTenantOfUser
        {
            get { return _userCodeTenantOfUser; }
            set
            {
                if (_userCodeTenantOfUser == value)
                    return;
                _userCodeTenantOfUser = value;

#if SILVERLIGHT
                OnPropertyChanged("UserCodeTenantOfUser");
#endif
            }
        }

        [DataMember]
        public string UserStaffName { get; set; }

        public List<int> GetServiceBookingQualificationList()
        {
            var list = new List<int>();
            if (String.IsNullOrWhiteSpace(ServiceBookingQualification))
                return list;

            var splt = ServiceBookingQualification.Split('|');
            foreach (var entry in splt)
            {
                int code;
                if (int.TryParse(entry, out code))
                    list.Add(code);
            }

            return list;
        }
    }
}
