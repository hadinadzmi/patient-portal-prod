using PatientPortalBackend.Models.MedCubesModels.Core;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Name = "UiDesktop", Namespace = "MedCubes.Framework.Models")]
    public partial class UiDesktop : DomainBaseModel
    {
        #region Constants
        public static readonly string UIDESKTOPID = "UiDesktopId";
        public static readonly string TITLE = "Title";
        public static readonly string DESCRIPTION = "Description";
        public static readonly string LAYOUTXAML = "LayoutXaml";
        public static readonly string TENANTID = "TenantId";
        public static readonly string CUSTOMERID = "CustomerId";
        public static readonly string RECORDSTATE = "RecordState";
        public static readonly string ROWVERSION = "RowVersion";
        public static readonly string ICON = "Icon";
        public static readonly string PKID = "PkId";
        public static readonly string DEFAULTSERVICEUNITID = "DefaultServiceUnitId";
        public static readonly string DEFAULTEXAMUNITID = "DefaultExamUnitId";
        public static readonly string ISEXAMUNITTOSELECT = "IsExamUnitToSelect";

        #endregion


        #region Constructor

        public UiDesktop()
        {

        }

        #endregion


        #region Primitive Properties

        private System.Guid _uiDesktopId;
        
        [DataMember]
        public System.Guid UiDesktopId
        {
            get
            {
                return _uiDesktopId;
            }
            set
            {
                if (_uiDesktopId == value) return;
                _uiDesktopId = value;
#if SILVERLIGHT
    		   OnPropertyChanged(UIDESKTOPID);
#endif
            }
        }

        private string _title;
        
        [DataMember]
        public string Title
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
                if (_description == value) return;
                _description = value;
#if SILVERLIGHT
    		   OnPropertyChanged(DESCRIPTION);
#endif
            }
        }

        private string _layoutXaml;
        
        [DataMember]
        public string LayoutXaml
        {
            get
            {
                return _layoutXaml;
            }
            set
            {
                if (_layoutXaml == value) return;
                _layoutXaml = value;
#if SILVERLIGHT
    		   OnPropertyChanged(LAYOUTXAML);
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

        private byte[] _icon;
        
        [DataMember]
        public byte[] Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                if (_icon == value) return;
                _icon = value;
#if SILVERLIGHT
    		   OnPropertyChanged(ICON);
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

        private Nullable<long> _defaultServiceUnitId;
        
        [DataMember]
        public Nullable<long> DefaultServiceUnitId
        {
            get
            {
                return _defaultServiceUnitId;
            }
            set
            {
                if (_defaultServiceUnitId == value) return;
                _defaultServiceUnitId = value;
#if SILVERLIGHT
    		    OnPropertyChanged(DEFAULTSERVICEUNITID);
#endif
            }
        }

        private Nullable<long> _defaultExamUnitId;
        
        [DataMember]
        public Nullable<long> DefaultExamUnitId
        {
            get
            {
                return _defaultExamUnitId;
            }
            set
            {
                if (_defaultExamUnitId == value) return;
                _defaultExamUnitId = value;
#if SILVERLIGHT
    		    OnPropertyChanged(DEFAULTEXAMUNITID);
#endif
            }
        }

        private bool _isExamUnitToSelect;
        
        [DataMember]
        public bool IsExamUnitToSelect
        {
            get
            {
                return _isExamUnitToSelect;
            }
            set
            {
                if (_isExamUnitToSelect == value) return;
                _isExamUnitToSelect = value;
#if SILVERLIGHT
    		    OnPropertyChanged(ISEXAMUNITTOSELECT);
#endif
            }
        }

        #endregion

    }
}
