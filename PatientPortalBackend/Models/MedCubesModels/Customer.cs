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
    [DataContract(Name = "Customer", Namespace = "MedCubes.Framework.Models")]
    public partial class Customer : DomainBaseModel
    {
        #region Constants
        public static readonly string CUSTOMERID = "CustomerId";
        public static readonly string CUSTOMERKEY = "CustomerKey";
        public static readonly string NAME = "Name";
        public static readonly string RECORDSTATE = "RecordState";
        public static readonly string ROWVERSION = "RowVersion";
        public static readonly string EMAIL = "Email";
        public static readonly string VALIDFROM = "ValidFrom";
        public static readonly string VALIDTO = "ValidTo";
        public static readonly string PHONENO = "PhoneNo";
        public static readonly string HOMEPAGE = "Homepage";
        public static readonly string INFORMATION = "Information";
        public static readonly string CODE = "Code";
        public static readonly string CULTURE = "Culture";
        public static readonly string FAXNO = "FaxNo";

        #endregion


        #region Constructor

        #endregion


        #region Primitive Properties

        private System.Guid _customerKey;
        
        [DataMember]
        public System.Guid CustomerKey
        {
            get
            {
                return _customerKey;
            }
            set
            {
                if (_customerKey == value) return;
                _customerKey = value;
#if SILVERLIGHT
    		   OnPropertyChanged(CUSTOMERKEY);
#endif
            }
        }

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

        private string _homepage;
        
        [DataMember]
        public string Homepage
        {
            get
            {
                return _homepage;
            }
            set
            {
                if (_homepage == value) return;
                _homepage = value;
#if SILVERLIGHT
    		   OnPropertyChanged(HOMEPAGE);
#endif
            }
        }

        private string _information;
        
        [DataMember]
        public string Information
        {
            get
            {
                return _information;
            }
            set
            {
                if (_information == value) return;
                _information = value;
#if SILVERLIGHT
    		   OnPropertyChanged(INFORMATION);
#endif
            }
        }

        private string _code;
        
        [DataMember]
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (_code == value) return;
                _code = value;
#if SILVERLIGHT
    		   OnPropertyChanged(CODE);
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

        #endregion

    }
}
