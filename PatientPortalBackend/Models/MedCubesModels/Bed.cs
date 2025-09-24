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
    [DataContract(Name = "Bed", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class Bed : DomainBaseModel 
    {
        #region Constants
    	public static readonly string BEDID = "BedId";
    	public static readonly string SHORTNAME = "ShortName";
    	public static readonly string NAME = "Name";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ROOMID = "RoomId";
    	public static readonly string VALIDFROM = "ValidFrom";
    	public static readonly string VALIDTO = "ValidTo";
    	public static readonly string ADDITIONALINFORMATION = "AdditionalInformation";
    	public static readonly string ISACTIVE = "IsActive";
    	public static readonly string PHONE = "Phone";

        #endregion

        #region Constructor
    	public Bed()
    	{	 
        }
        #endregion

    	 
        #region Primitive Properties
    	
    	private long _bedId;
    		
        
    	[DataMember]		
    	public  long BedId
        {    
            get 
    		{	
    			return _bedId;
    		}
            set
    		{
    			if(_bedId == value)
    			{
    				return;
    			}
    						
    			_bedId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(BEDID);
    			 #endif
    		}
        }
    	
    	private string _shortName;
    		
        
    	[DataMember]		
    	public  string ShortName
        {    
            get 
    		{	
    			return _shortName;
    		}
            set
    		{
    			if(_shortName == value)
    			{
    				return;
    			}
    						
    			_shortName = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(SHORTNAME);
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
    	
    	private long _roomId;
    		
        
    	[DataMember]		
    	public  long RoomId
        {    
            get 
    		{	
    			return _roomId;
    		}
            set
    		{
    			if(_roomId == value)
    			{
    				return;
    			}
    						
    			_roomId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ROOMID);
    			 #endif
    		}
        }
    	
    	private System.DateTime _validFrom;
    		
        
    	[DataMember]		
    	public  System.DateTime ValidFrom
        {    
            get 
    		{	
    			return _validFrom;
    		}
            set
    		{
    			if(_validFrom == value)
    			{
    				return;
    			}
    						
    			_validFrom = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(VALIDFROM);
    			 #endif
    		}
        }
    	
    	private Nullable<System.DateTime> _validTo;
    		
        
    	[DataMember]		
    	public  Nullable<System.DateTime> ValidTo
        {    
            get 
    		{	
    			return _validTo;
    		}
            set
    		{
    			if(_validTo == value)
    			{
    				return;
    			}
    						
    			_validTo = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(VALIDTO);
    			 #endif
    		}
        }
    	
    	private string _additionalInformation;
    		
        
    	[DataMember]		
    	public  string AdditionalInformation
        {    
            get 
    		{	
    			return _additionalInformation;
    		}
            set
    		{
    			if(_additionalInformation == value)
    			{
    				return;
    			}
    						
    			_additionalInformation = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ADDITIONALINFORMATION);
    			 #endif
    		}
        }
    	
    	private Nullable<bool> _isActive;
    		
        
    	[DataMember]		
    	public  Nullable<bool> IsActive
        {    
            get 
    		{	
    			return _isActive;
    		}
            set
    		{
    			if(_isActive == value)
    			{
    				return;
    			}
    						
    			_isActive = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ISACTIVE);
    			 #endif
    		}
        }
    	
    	private string _phone;
    		
        
    	[DataMember]		
    	public  string Phone
        {    
            get 
    		{	
    			return _phone;
    		}
            set
    		{
    			if(_phone == value)
    			{
    				return;
    			}
    						
    			_phone = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(PHONE);
    			 #endif
    		}
        }

        #endregion

        #region Navigation Properties
    
    		 
    		
      
    	[IgnoreDataMember]
        public  Room Room
        {
            get; set; 
    
        }    

        #endregion

    }
}
