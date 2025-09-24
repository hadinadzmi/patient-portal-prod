using PatientPortalBackend.Models.MedCubesModels.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Attention!!!
    /// Place new functionality into separate partial class as this class-file will be recreated
    /// if tt procedure is executed again (your modifications would be lost)!
    /// </summary>
    [DataContract(Name = "Tenant", Namespace = "MedCubes.Framework.Models")]
    public partial class Tenant : DomainBaseModel
    {
        #region Constants
        public static readonly string TENANTID = "TenantId";
        public static readonly string NAME = "Name";
        public static readonly string RECORDSTATE = "RecordState";
        public static readonly string ROWVERSION = "RowVersion";
        public static readonly string CUSTOMERID = "CustomerId";
        public static readonly string VALIDFROM = "ValidFrom";
        public static readonly string VALIDTO = "ValidTo";
        public static readonly string KEY = "Key";
        public static readonly string REPORTINGPASSWORD = "ReportingPassword";
        public static readonly string CULTURE = "Culture";
        public static readonly string ADDRESSCOUNTRYCODE = "AddressCountryCode";
        public static readonly string ADDRESSZIPCODE = "AddressZipCode";
        public static readonly string ADDRESSCITYNAME = "AddressCityName";
        public static readonly string ADDRESSSTREET = "AddressStreet";
        public static readonly string EMAIL = "Email";
        public static readonly string WEBSITE = "Website";
        public static readonly string CONTACTPERSON = "ContactPerson";
        public static readonly string LOGO = "Logo";
        public static readonly string LOGOHEADERPORTRAIT = "LogoHeaderPortrait";
        public static readonly string LOGOHEADERLANDSCAPE = "LogoHeaderLandscape";
        public static readonly string LOGOFOOTERPORTRAIT = "LogoFooterPortrait";
        public static readonly string LOGOFOOTERLANDSCAPE = "LogoFooterLandscape";
        public static readonly string NATIONALITY = "Nationality";
        public static readonly string FAXNO = "FaxNo";
        public static readonly string PHONENO = "PhoneNo";

        #endregion


        #region Constructor

        public Tenant()
        {
        }

        #endregion


        #region Primitive Properties

        private string _name;
        
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value) return;
                _name = value;
#if SILVERLIGHT
    		   OnPropertyChanged(NAME);
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

        private Nullable<System.DateTime> _validFrom;
        
        [DataMember]
        public Nullable<System.DateTime> ValidFrom
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

        private string _key;
        
        [DataMember]
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                if (_key == value) return;
                _key = value;
#if SILVERLIGHT
    		   OnPropertyChanged(KEY);
#endif
            }
        }

        private byte[] _reportingPassword;
        
        [DataMember]
        public byte[] ReportingPassword
        {
            get
            {
                return _reportingPassword;
            }
            set
            {
                if (_reportingPassword == value) return;
                _reportingPassword = value;
#if SILVERLIGHT
    		   OnPropertyChanged(REPORTINGPASSWORD);
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
                if (_addressCountryCode == value) return;
                _addressCountryCode = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ADDRESSCOUNTRYCODE);
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
                if (_addressZipCode == value) return;
                _addressZipCode = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ADDRESSZIPCODE);
#endif
            }
        }

        private string _addressCityName;
        
        [DataMember]
        public string AddressCityName
        {
            get
            {
                return _addressCityName;
            }
            set
            {
                if (_addressCityName == value) return;
                _addressCityName = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ADDRESSCITYNAME);
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
                if (_addressStreet == value) return;
                _addressStreet = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ADDRESSSTREET);
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
                if (_email == value) return;
                _email = value;
#if SILVERLIGHT
    		   OnPropertyChanged(EMAIL);
#endif
            }
        }

        private string _website;
        
        [DataMember]
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                if (_website == value) return;
                _website = value;
#if SILVERLIGHT
    		   OnPropertyChanged(WEBSITE);
#endif
            }
        }

        private string _contactPerson;
        
        [DataMember]
        public string ContactPerson
        {
            get
            {
                return _contactPerson;
            }
            set
            {
                if (_contactPerson == value) return;
                _contactPerson = value;
#if SILVERLIGHT
    		   OnPropertyChanged(CONTACTPERSON);
#endif
            }
        }

        private byte[] _logo;
        
        [DataMember]
        public byte[] Logo
        {
            get
            {
                return _logo;
            }
            set
            {
                if (_logo == value) return;
                _logo = value;
#if SILVERLIGHT
    		   OnPropertyChanged(LOGO);
#endif
            }
        }

        private byte[] _logoHeaderPortrait;
        
        [DataMember]
        public byte[] LogoHeaderPortrait
        {
            get
            {
                return _logoHeaderPortrait;
            }
            set
            {
                if (_logoHeaderPortrait == value) return;
                _logoHeaderPortrait = value;
#if SILVERLIGHT
    		   OnPropertyChanged(LOGOHEADERPORTRAIT);
#endif
            }
        }

        private byte[] _logoHeaderLandscape;
        
        [DataMember]
        public byte[] LogoHeaderLandscape
        {
            get
            {
                return _logoHeaderLandscape;
            }
            set
            {
                if (_logoHeaderLandscape == value) return;
                _logoHeaderLandscape = value;
#if SILVERLIGHT
    		   OnPropertyChanged(LOGOHEADERLANDSCAPE);
#endif
            }
        }

        private byte[] _logoFooterPortrait;
        
        [DataMember]
        public byte[] LogoFooterPortrait
        {
            get
            {
                return _logoFooterPortrait;
            }
            set
            {
                if (_logoFooterPortrait == value) return;
                _logoFooterPortrait = value;
#if SILVERLIGHT
    		   OnPropertyChanged(LOGOFOOTERPORTRAIT);
#endif
            }
        }

        private byte[] _logoFooterLandscape;
        
        [DataMember]
        public byte[] LogoFooterLandscape
        {
            get
            {
                return _logoFooterLandscape;
            }
            set
            {
                if (_logoFooterLandscape == value) return;
                _logoFooterLandscape = value;
#if SILVERLIGHT
    		   OnPropertyChanged(LOGOFOOTERLANDSCAPE);
#endif
            }
        }

        private Nullable<int> _nationality;
        
        [DataMember]
        public Nullable<int> Nationality
        {
            get
            {
                return _nationality;
            }
            set
            {
                if (_nationality == value) return;
                _nationality = value;
#if SILVERLIGHT
    		   OnPropertyChanged(NATIONALITY);
#endif
            }
        }

        private string _faxNo;
        
        [DataMember]
        public string FaxNo
        {
            get
            {
                return _faxNo;
            }
            set
            {
                if (_faxNo == value) return;
                _faxNo = value;
#if SILVERLIGHT
    		   OnPropertyChanged(FAXNO);
#endif
            }
        }

        private string _phoneNo;
        
        [DataMember]
        public string PhoneNo
        {
            get
            {
                return _phoneNo;
            }
            set
            {
                if (_phoneNo == value) return;
                _phoneNo = value;
#if SILVERLIGHT
    		   OnPropertyChanged(PHONENO);
#endif
            }
        }

        #endregion

        #region Navigation Properties




        [JsonIgnore]
        public Customer Customer
        {
            get; set;
        }

        #endregion

    }
}
