using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Name = "Resource", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class Resource : DomainBaseModel 
    {
        #region Constants
    	public static readonly string PKID = "PkId";
    	public static readonly string RESOURCEID = "ResourceId";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string SERVICEUNITID = "ServiceUnitId";
    	public static readonly string TYPE = "Type";
    	public static readonly string MAINDATAID = "MainDataId";
    	public static readonly string NAME = "Name";
    	public static readonly string CREATEORDER = "CreateOrder";
    	public static readonly string ORDERSERVICEUNITID = "OrderServiceUnitId";
    	public static readonly string ORDEREXAMUNITID = "OrderExamUnitId";
    	public static readonly string ORDERUSERID = "OrderUserId";
    	public static readonly string ICON = "Icon";
    	public static readonly string COLOR = "Color";
    	public static readonly string ADDITIONALINFO = "AdditionalInfo";
    	public static readonly string CLINICGROUP = "ClinicGroup";
    	public static readonly string REMARK = "Remark";

        #endregion

        #region Constructor
    	public Resource()
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
    	
    	private long _serviceUnitId;
        
    	[DataMember]	
    	public  long ServiceUnitId
        {    
            get 
    		{	
    			return _serviceUnitId;
    		}
            set
    		{
    			if(_serviceUnitId == value)
    			{
    				return;
    			}
    						
    			_serviceUnitId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(SERVICEUNITID);
    			 #endif
    		}
        }
    	
    	private Nullable<int> _type;
        
    	[DataMember]	
    	public  Nullable<int> Type
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
    	
    	private Nullable<long> _mainDataId;
        
    	[DataMember]	
    	public  Nullable<long> MainDataId
        {    
            get 
    		{	
    			return _mainDataId;
    		}
            set
    		{
    			if(_mainDataId == value)
    			{
    				return;
    			}
    						
    			_mainDataId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(MAINDATAID);
    			 #endif
    		}
        }
    	
    	private string _name;
        
    	[DataMember]	
    	public  string Name
        {    
            get 
    		{	
    			return _name;
    		}
            set
    		{
    			if(_name == value)
    			{
    				return;
    			}
    						
    			_name = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(NAME);
    			 #endif
    		}
        }
    	
    	private Nullable<bool> _createOrder;
        
    	[DataMember]	
    	public  Nullable<bool> CreateOrder
        {    
            get 
    		{	
    			return _createOrder;
    		}
            set
    		{
    			if(_createOrder == value)
    			{
    				return;
    			}
    						
    			_createOrder = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(CREATEORDER);
    			 #endif
    		}
        }
    	
    	private Nullable<long> _orderServiceUnitId;
        
    	[DataMember]	
    	public  Nullable<long> OrderServiceUnitId
        {    
            get 
    		{	
    			return _orderServiceUnitId;
    		}
            set
    		{
    			if(_orderServiceUnitId == value)
    			{
    				return;
    			}
    						
    			_orderServiceUnitId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ORDERSERVICEUNITID);
    			 #endif
    		}
        }
    	
    	private Nullable<long> _orderExamUnitId;
        
    	[DataMember]	
    	public  Nullable<long> OrderExamUnitId
        {    
            get 
    		{	
    			return _orderExamUnitId;
    		}
            set
    		{
    			if(_orderExamUnitId == value)
    			{
    				return;
    			}
    						
    			_orderExamUnitId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ORDEREXAMUNITID);
    			 #endif
    		}
        }
    	
    	private Nullable<long> _orderUserId;
        
    	[DataMember]	
    	public  Nullable<long> OrderUserId
        {    
            get 
    		{	
    			return _orderUserId;
    		}
            set
    		{
    			if(_orderUserId == value)
    			{
    				return;
    			}
    						
    			_orderUserId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ORDERUSERID);
    			 #endif
    		}
        }
    	
    	private byte[] _icon;
        
    	[DataMember]	
    	public  byte[] Icon
        {    
            get 
    		{	
    			return _icon;
    		}
            set
    		{
    			if(_icon == value)
    			{
    				return;
    			}
    						
    			_icon = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ICON);
    			 #endif
    		}
        }
    	
    	private string _color;
        
    	[DataMember]	
    	public  string Color
        {    
            get 
    		{	
    			return _color;
    		}
            set
    		{
    			if(_color == value)
    			{
    				return;
    			}
    						
    			_color = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(COLOR);
    			 #endif
    		}
        }
    	
    	private string _additionalInfo;
        
    	[DataMember]	
    	public  string AdditionalInfo
        {    
            get 
    		{	
    			return _additionalInfo;
    		}
            set
    		{
    			if(_additionalInfo == value)
    			{
    				return;
    			}
    						
    			_additionalInfo = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ADDITIONALINFO);
    			 #endif
    		}
        }
    	
    	private string _clinicGroup;
        
    	[DataMember]	
    	public  string ClinicGroup
        {    
            get 
    		{	
    			return _clinicGroup;
    		}
            set
    		{
    			if(_clinicGroup == value)
    			{
    				return;
    			}
    						
    			_clinicGroup = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(CLINICGROUP);
    			 #endif
    		}
        }
    	
    	private string _remark;
        
    	[DataMember]	
    	public  string Remark
        {    
            get 
    		{	
    			return _remark;
    		}
            set
    		{
    			if(_remark == value)
    			{
    				return;
    			}
    						
    			_remark = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(REMARK);
    			 #endif
    		}
        }

        #endregion

    }
}
