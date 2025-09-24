using PatientPortalBackend.Models.MedCubesModels.Core;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Attention!!!
    /// Place new functionality into separate partial class as this class-file will be recreated
    /// if tt procedure is executed again (your modifications would be lost)!
    /// </summary>
    [DataContract(Name = "ResourceTime", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class ResourceTime : DomainBaseModel 
    {
        #region Constants
    	public static readonly string PKID = "PkId";
    	public static readonly string RESOURCETIMEID = "ResourceTimeId";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string RESOURCEID = "ResourceId";
    	public static readonly string TYPE = "Type";
    	public static readonly string WEEKDAY = "Weekday";
    	public static readonly string TIMEFROM = "TimeFrom";
    	public static readonly string TIMEUNTIL = "TimeUntil";
    	public static readonly string COMMENT = "Comment";
    	public static readonly string MAXQUANTITY = "MaxQuantity";
    	public static readonly string MAXEXTRAQUANTITY = "MaxExtraQuantity";
    	public static readonly string ALLOWOVERBOOK = "AllowOverbook";
    	public static readonly string CREATEUSERID = "CreateUserId";
    	public static readonly string CREATEDATETIME = "CreateDateTime";
    	public static readonly string CLOSETYPE = "CloseType";
    	public static readonly string RESERVEDID = "ReservedId";

        #endregion

        #region Constructor
    	public ResourceTime()
    	{	 
        }
        #endregion

    	 
        #region Primitive Properties
    	
    	private long _pkId;
        
    	[DataMember]	
    	public  long PkId
        {    
            get 
    		{	
    			return _pkId;
    		}
            set
    		{
    			if(_pkId == value)
    			{
    				return;
    			}
    						
    			_pkId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(PKID);
    			 #endif
    		}
        }
    	
    	private System.Guid _resourceTimeId;
        
    	[DataMember]	
    	public  System.Guid ResourceTimeId
        {    
            get 
    		{	
    			return _resourceTimeId;
    		}
            set
    		{
    			if(_resourceTimeId == value)
    			{
    				return;
    			}
    						
    			_resourceTimeId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(RESOURCETIMEID);
    			 #endif
    		}
        }
    	
    	private byte _recordState;
        
    	[DataMember]	
    	public  byte RecordState
        {    
            get 
    		{	
    			return _recordState;
    		}
            set
    		{
    			if(_recordState == value)
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
    	public  byte[] RowVersion
        {    
            get 
    		{	
    			return _rowVersion;
    		}
            set
    		{
    			if(_rowVersion == value)
    			{
    				return;
    			}
    						
    			_rowVersion = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ROWVERSION);
    			 #endif
    		}
        }
    	
    	private System.Guid _resourceId;
        
    	[DataMember]	
    	public  System.Guid ResourceId
        {    
            get 
    		{	
    			return _resourceId;
    		}
            set
    		{
    			if(_resourceId == value)
    			{
    				return;
    			}
    						
    			_resourceId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(RESOURCEID);
    			 #endif
    		}
        }
    	
    	private int _type;
        
    	[DataMember]	
    	public  int Type
        {    
            get 
    		{	
    			return _type;
    		}
            set
    		{
    			if(_type == value)
    			{
    				return;
    			}
    						
    			_type = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(TYPE);
    			 #endif
    		}
        }
    	
    	private Nullable<int> _weekday;
        
    	[DataMember]	
    	public  Nullable<int> Weekday
        {    
            get 
    		{	
    			return _weekday;
    		}
            set
    		{
    			if(_weekday == value)
    			{
    				return;
    			}
    						
    			_weekday = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(WEEKDAY);
    			 #endif
    		}
        }
    	
    	private System.DateTimeOffset _timeFrom;
        
    	[DataMember]	
    	public  System.DateTimeOffset TimeFrom
        {    
            get 
    		{
    		#if SILVERLIGHT
    			return _timeFrom.ToLocalTime();
    			#else
    			return _timeFrom;
    			#endif
    		}
            set
    		{
    			if (_timeFrom == value && value.Offset == _timeFrom.Offset)
    				{
    					return;
    				}
    						
    			_timeFrom = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(TIMEFROM);
    			 #endif
    		}
        }
    	
    	private System.DateTimeOffset _timeUntil;
        
    	[DataMember]	
    	public  System.DateTimeOffset TimeUntil
        {    
            get 
    		{
    		#if SILVERLIGHT
    			return _timeUntil.ToLocalTime();
    			#else
    			return _timeUntil;
    			#endif
    		}
            set
    		{
    			if (_timeUntil == value && value.Offset == _timeUntil.Offset)
    				{
    					return;
    				}
    						
    			_timeUntil = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(TIMEUNTIL);
    			 #endif
    		}
        }
    	
    	private string _comment;
        
    	[DataMember]	
    	public  string Comment
        {    
            get 
    		{	
    			return _comment;
    		}
            set
    		{
    			if(_comment == value)
    			{
    				return;
    			}
    						
    			_comment = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(COMMENT);
    			 #endif
    		}
        }
    	
    	private Nullable<int> _maxQuantity;
        
    	[DataMember]	
    	public  Nullable<int> MaxQuantity
        {    
            get 
    		{	
    			return _maxQuantity;
    		}
            set
    		{
    			if(_maxQuantity == value)
    			{
    				return;
    			}
    						
    			_maxQuantity = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(MAXQUANTITY);
    			 #endif
    		}
        }
    	
    	private Nullable<int> _maxExtraQuantity;
        
    	[DataMember]	
    	public  Nullable<int> MaxExtraQuantity
        {    
            get 
    		{	
    			return _maxExtraQuantity;
    		}
            set
    		{
    			if(_maxExtraQuantity == value)
    			{
    				return;
    			}
    						
    			_maxExtraQuantity = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(MAXEXTRAQUANTITY);
    			 #endif
    		}
        }
    	
    	private Nullable<bool> _allowOverbook;
        
    	[DataMember]	
    	public  Nullable<bool> AllowOverbook
        {    
            get 
    		{	
    			return _allowOverbook;
    		}
            set
    		{
    			if(_allowOverbook == value)
    			{
    				return;
    			}
    						
    			_allowOverbook = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ALLOWOVERBOOK);
    			 #endif
    		}
        }
    	
    	private Nullable<long> _createUserId;
        
    	[DataMember]	
    	public  Nullable<long> CreateUserId
        {    
            get 
    		{	
    			return _createUserId;
    		}
            set
    		{
    			if(_createUserId == value)
    			{
    				return;
    			}
    						
    			_createUserId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(CREATEUSERID);
    			 #endif
    		}
        }
    	
    	private Nullable<System.DateTimeOffset> _createDateTime;
        
    	[DataMember]	
    	public  Nullable<System.DateTimeOffset> CreateDateTime
        {    
            get 
    		{if(_createDateTime == null) return null;
    				#if SILVERLIGHT
    			return _createDateTime.Value.ToLocalTime();
    			#else
    			return _createDateTime;
    			#endif
    			}
            set
    		{
    			if (_createDateTime == value && (value != null && _createDateTime != null && value.Value.Offset == _createDateTime.Value.Offset))
    			{
    				return;
    			}
    						
    			_createDateTime = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(CREATEDATETIME);
    			 #endif
    		}
        }
    	
    	private Nullable<int> _closeType;
        
    	[DataMember]	
    	public  Nullable<int> CloseType
        {    
            get 
    		{	
    			return _closeType;
    		}
            set
    		{
    			if(_closeType == value)
    			{
    				return;
    			}
    						
    			_closeType = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(CLOSETYPE);
    			 #endif
    		}
        }
    	
    	private Nullable<System.Guid> _reservedId;
        
    	[DataMember]	
    	public  Nullable<System.Guid> ReservedId
        {    
            get 
    		{	
    			return _reservedId;
    		}
            set
    		{
    			if(_reservedId == value)
    			{
    				return;
    			}
    						
    			_reservedId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(RESERVEDID);
    			 #endif
    		}
        }

        #endregion

    }
}
