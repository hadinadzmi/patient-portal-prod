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
    [DataContract(Name = "Room", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class Room : DomainBaseModel 
    {
        #region Constants
    	public static readonly string ROOMID = "RoomId";
    	public static readonly string SHORTNAME = "ShortName";
    	public static readonly string NAME = "Name";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string SERVICEUNITID = "ServiceUnitId";
    	public static readonly string VALIDFROM = "ValidFrom";
    	public static readonly string VALIDTO = "ValidTo";

        #endregion

        #region Constructor
    	public Room()
    	{	 
        	   Bed = new List<Bed>();
        }
        #endregion

    	 
        #region Primitive Properties
    	
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

        #endregion

        #region Navigation Properties
    
    		 
    		
        
        [IgnoreDataMember]
        public List<Bed> Bed {get; set;}
    
    		 
    		
      
    	[IgnoreDataMember]
        public  ServiceUnit ServiceUnit
        {
            get; set; 
    
        }    

        #endregion

    }
}
