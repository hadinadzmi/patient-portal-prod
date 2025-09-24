using PatientPortalBackend.Models.MedCubesModels.Core;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Name = "Profile", Namespace = "MedCubes.Framework.Models")]
    public partial class Profile : DomainBaseModel
    {
        #region Constants
        public static readonly string NAME = "Name";
        public static readonly string RECORDSTATE = "RecordState";
        public static readonly string ROWVERSION = "RowVersion";
        public static readonly string CUSTOMERID = "CustomerId";
        public static readonly string TENANTID = "TenantId";
        public static readonly string PKID = "PkId";
        public static readonly string PROFILEID = "ProfileId";
        public static readonly string VALIDFROM = "ValidFrom";
        public static readonly string VALIDTO = "ValidTo";

        #endregion


        #region Constructor

        public Profile()
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
                if (_pkId == value) return;
                _pkId = value;
#if SILVERLIGHT
    		   OnPropertyChanged(PKID);
#endif
            }
        }

        private System.Guid _profileId;
        
        [DataMember]
        public System.Guid ProfileId
        {
            get
            {
                return _profileId;
            }
            set
            {
                if (_profileId == value) return;
                _profileId = value;
#if SILVERLIGHT
    		   OnPropertyChanged(PROFILEID);
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

        #endregion

    }
}
