using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Attention!!!
    /// Place new functionality into separate partial class as this class-file will be recreated
    /// if tt procedure is executed again (your modifications would be lost)!
    /// </summary>
    [DataContract(Name = "PatientAllergy", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class PatientAllergy : DomainBaseModel
    {
        #region Constants
        public static readonly string PKID = "PkId";
        public static readonly string CUSTOMERID = "CustomerId";
        public static readonly string TENANTID = "TenantId";
        public static readonly string RECORDSTATE = "RecordState";
        public static readonly string ROWVERSION = "RowVersion";
        public static readonly string CODE = "Code";
        public static readonly string NAME = "Name";
        public static readonly string TYPE = "Type";
        public static readonly string ADDITIONALTEXT = "AdditionalText";
        public static readonly string DESCRIPTION = "Description";
        public static readonly string INFECTIONDATE = "InfectionDate";
        public static readonly string ALLERGYSTATE = "AllergyState";
        public static readonly string CREATINGDATETIMEOFFSET = "CreatingDateTimeOffset";
        public static readonly string PATIENTID = "PatientId";
        public static readonly string CREATEUSERID = "CreateUserId";

        #endregion

        #region Constructor
        public PatientAllergy()
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
                if (_code == value)
                {
                    return;
                }

                _code = value;

#if SILVERLIGHT
    			 OnPropertyChanged(CODE);
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
                if (_name == value)
                {
                    return;
                }

                _name = value;

#if SILVERLIGHT
    			 OnPropertyChanged(NAME);
#endif
            }
        }

        private Nullable<int> _type;
        
        [DataMember]
        public Nullable<int> Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (_type == value)
                {
                    return;
                }

                _type = value;

#if SILVERLIGHT
    			 OnPropertyChanged(TYPE);
#endif
            }
        }

        private string _additionalText;
        
        [DataMember]
        public string AdditionalText
        {
            get
            {
                return _additionalText;
            }
            set
            {
                if (_additionalText == value)
                {
                    return;
                }

                _additionalText = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ADDITIONALTEXT);
#endif
            }
        }

        private string _description;
        
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;

#if SILVERLIGHT
    			 OnPropertyChanged(DESCRIPTION);
#endif
            }
        }

        private Nullable<System.DateTime> _infectionDate;
        
        [DataMember]
        public Nullable<System.DateTime> InfectionDate
        {
            get
            {
                return _infectionDate;
            }
            set
            {
                if (_infectionDate == value)
                {
                    return;
                }

                _infectionDate = value;

#if SILVERLIGHT
    			 OnPropertyChanged(INFECTIONDATE);
#endif
            }
        }

        private Nullable<int> _allergyState;
        
        [DataMember]
        public Nullable<int> AllergyState
        {
            get
            {
                return _allergyState;
            }
            set
            {
                if (_allergyState == value)
                {
                    return;
                }

                _allergyState = value;

#if SILVERLIGHT
    			 OnPropertyChanged(ALLERGYSTATE);
#endif
            }
        }

        private System.DateTimeOffset _creatingDateTimeOffset;
        
        [DataMember]
        public System.DateTimeOffset CreatingDateTimeOffset
        {
            get
            {
#if SILVERLIGHT
    			return _creatingDateTimeOffset.ToLocalTime();
#else
                return _creatingDateTimeOffset;
#endif
            }
            set
            {
                if (_creatingDateTimeOffset == value && value.Offset == _creatingDateTimeOffset.Offset)
                {
                    return;
                }

                _creatingDateTimeOffset = value;

#if SILVERLIGHT
    			 OnPropertyChanged(CREATINGDATETIMEOFFSET);
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

        private long _createUserId;
        
        [DataMember]
        public long CreateUserId
        {
            get
            {
                return _createUserId;
            }
            set
            {
                if (_createUserId == value)
                {
                    return;
                }

                _createUserId = value;

#if SILVERLIGHT
    			 OnPropertyChanged(CREATEUSERID);
#endif
            }
        }

        #endregion

    }
}
