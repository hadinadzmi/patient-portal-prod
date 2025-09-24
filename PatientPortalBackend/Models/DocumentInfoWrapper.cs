using PatientPortalBackend.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public partial class DocumentInfoWrapper : DomainBaseModel
    {
        public override ModelValidationResult ValidateModel()
        {
            return new ModelValidationResult();
        }
        
        public bool HasCreatePermission { get; set; }
        public String CreatePermission { get; set; }

        
        public bool HasReadPermission { get; set; }
        public String ReadPermission { get; set; }

        
        public bool HasUpdatePermission { get; set; }
        public String UpdatePermission { get; set; }

        
        public bool HasDeletePermission { get; set; }
        public String DeletePermission { get; set; }

        
        public bool HasDownloadPermission { get; set; }
        public String DownloadPermission { get; set; }

        
        public bool HasFinalizePermission { get; set; }
        public String FinalizePermission { get; set; }

        
        public bool IsRead { get; set; }

        private Nullable<DateTimeOffset> _lastReadStatusSet;
        
        public Nullable<DateTimeOffset> LastReadStatusSet
        {
            get
            {
#if SILVERLIGHT
            if(_lastReadStatusSet != null && TimeZoneInfo.Local.GetUtcOffset(_lastReadStatusSet.Value) != _lastReadStatusSet.Value.Offset)
                _lastReadStatusSet = _lastReadStatusSet.Value.ToLocalTime();
#endif
                return _lastReadStatusSet;
            }
            set
            {
                if (_lastReadStatusSet == value && (value != null && _lastReadStatusSet != null && value.Value.Offset == _lastReadStatusSet.Value.Offset))
                    return;
                _lastReadStatusSet = value;
            }
        }

        
        public bool IsApproved { get; set; }

        private Nullable<DateTimeOffset> _lastApprovedStatusSet;

        
        public Nullable<DateTimeOffset> LastApprovedStatusSet
        {
            get
            {
#if SILVERLIGHT
                if (_lastApprovedStatusSet != null && TimeZoneInfo.Local.GetUtcOffset(_lastApprovedStatusSet.Value) != _lastApprovedStatusSet.Value.Offset)
                    _lastApprovedStatusSet = _lastApprovedStatusSet.Value.ToLocalTime();
#endif
                return _lastApprovedStatusSet;
            }
            set
            {
                if (_lastApprovedStatusSet == value && (value != null && _lastApprovedStatusSet != null && value.Value.Offset == _lastApprovedStatusSet.Value.Offset))
                    return;
                _lastApprovedStatusSet = value;
            }
        }

        private Nullable<DateTimeOffset> _finalizedStatusSet;
        
        public Nullable<DateTimeOffset> FinalizedStatusSet
        {
            get
            {
#if SILVERLIGHT
                if (_finalizedStatusSet != null && TimeZoneInfo.Local.GetUtcOffset(_finalizedStatusSet.Value) != _finalizedStatusSet.Value.Offset)
                    _finalizedStatusSet = _finalizedStatusSet.Value.ToLocalTime();
#endif
                return _finalizedStatusSet;
            }
            set
            {
                if (_finalizedStatusSet == value && (value != null && _finalizedStatusSet != null && value.Value.Offset == _finalizedStatusSet.Value.Offset))
                    return;
                _finalizedStatusSet = value;
            }
        }

        
        public String FinalizedStatusSetUserName { get; set; }


        public DocumentInfo DocumentInfoRecord { get; set; }


        public List<DocumentStatus> DocumentStatusList { get; set; }


        public double LuceneFulltextSearchScore { get; set; }

        
        public bool IsApprovedByAnotherUser { get; set; }

        
        public String ApprovedByUser { get; set; }


        #region Overrides of DomainBaseModel

        public override string GetHistoryKey()
        {
            return string.Empty;
        }

        #endregion
    }
}
