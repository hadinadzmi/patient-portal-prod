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
    [DataContract(Name = "ExaminationUnit", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class ExaminationUnit : DomainBaseModel 
    {
        #region Constants
    	public static readonly string EXAMUNITID = "ExamUnitId";
    	public static readonly string NAME = "Name";
    	public static readonly string SHORTNAME = "ShortName";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ISACTIVE = "IsActive";
    	public static readonly string ADDITIONALINFORMATION = "AdditionalInformation";
    	public static readonly string FROMTIME = "FromTime";
    	public static readonly string UNTILTIME = "UntilTime";
    	public static readonly string SERVICEUNITID = "ServiceUnitId";
    	public static readonly string VALIDFROM = "ValidFrom";
    	public static readonly string VALIDUNTIL = "ValidUntil";
    	public static readonly string ADDITIONALINFO2 = "AdditionalInfo2";

        #endregion

        #region Constructor
    	public ExaminationUnit()
    	{	 
        }
        #endregion

    	 
        #region Primitive Properties
    	
    	private long _examUnitId;
    		
        
    	[DataMember]		
    	public  long ExamUnitId
        {    
            get 
    		{	
    			return _examUnitId;
    		}
            set
    		{
    			if(_examUnitId == value)
    			{
    				return;
    			}
    						
    			_examUnitId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(EXAMUNITID);
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
    	
    	private Nullable<System.DateTimeOffset> _fromTime;
    		
        
    	[DataMember]		
    	public  Nullable<System.DateTimeOffset> FromTime
        {    
            get 
    		{if(_fromTime == null) return null;
    				#if SILVERLIGHT
    			return _fromTime.Value.ToLocalTime();
    			#else
    			return _fromTime;
    			#endif
    			}
            set
    		{
    			if (_fromTime == value && (value != null && _fromTime != null && value.Value.Offset == _fromTime.Value.Offset))
    			{
    				return;
    			}
    						
    			_fromTime = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(FROMTIME);
    			 #endif
    		}
        }
    	
    	private Nullable<System.DateTimeOffset> _untilTime;
    		
        
    	[DataMember]		
    	public  Nullable<System.DateTimeOffset> UntilTime
        {    
            get 
    		{if(_untilTime == null) return null;
    				#if SILVERLIGHT
    			return _untilTime.Value.ToLocalTime();
    			#else
    			return _untilTime;
    			#endif
    			}
            set
    		{
    			if (_untilTime == value && (value != null && _untilTime != null && value.Value.Offset == _untilTime.Value.Offset))
    			{
    				return;
    			}
    						
    			_untilTime = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(UNTILTIME);
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
    	
    	private Nullable<System.DateTime> _validFrom;
    		
        
    	[DataMember]		
    	public  Nullable<System.DateTime> ValidFrom
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
    	
    	private Nullable<System.DateTime> _validUntil;
    		
        
    	[DataMember]		
    	public  Nullable<System.DateTime> ValidUntil
        {    
            get 
    		{	
    			return _validUntil;
    		}
            set
    		{
    			if(_validUntil == value)
    			{
    				return;
    			}
    						
    			_validUntil = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(VALIDUNTIL);
    			 #endif
    		}
        }
    	
    	private string _additionalInfo2;
    		
        
    	[DataMember]		
    	public  string AdditionalInfo2
        {    
            get 
    		{	
    			return _additionalInfo2;
    		}
            set
    		{
    			if(_additionalInfo2 == value)
    			{
    				return;
    			}
    						
    			_additionalInfo2 = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ADDITIONALINFO2);
    			 #endif
    		}
        }

        #endregion

        #region Navigation Properties
    
    		 
    		
      
    	[IgnoreDataMember]
        public  ServiceUnit ServiceUnit
        {
            get; set; 
    
        }    

        #endregion

    }
}
