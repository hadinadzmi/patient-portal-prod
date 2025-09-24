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
    [DataContract(Name = "Department", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class Department : DomainBaseModel 
    {
        #region Constants
    	public static readonly string DEPARTMENTID = "DepartmentId";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string NAME = "Name";
    	public static readonly string SHORTNAME = "ShortName";
    	public static readonly string VALIDFROM = "ValidFrom";
    	public static readonly string VALIDUNTIL = "ValidUntil";
    	public static readonly string DEPARTMENTKEY = "DepartmentKey";
    	public static readonly string INFORMATION = "Information";

        #endregion

        #region Constructor
    	public Department()
    	{	 
        	   ServiceUnit = new List<ServiceUnit>();
        }
        #endregion

    	 
        #region Primitive Properties
    	
    	private long _departmentId;
    		
        
    	[DataMember]		
    	public  long DepartmentId
        {    
            get 
    		{	
    			return _departmentId;
    		}
            set
    		{
    			if(_departmentId == value)
    			{
    				return;
    			}
    						
    			_departmentId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(DEPARTMENTID);
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
    	
    	private string _departmentKey;
    		
        
    	[DataMember]		
    	public  string DepartmentKey
        {    
            get 
    		{	
    			return _departmentKey;
    		}
            set
    		{
    			if(_departmentKey == value)
    			{
    				return;
    			}
    						
    			_departmentKey = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(DEPARTMENTKEY);
    			 #endif
    		}
        }
    	
    	private string _information;
    		
        
    	[DataMember]		
    	public  string Information
        {    
            get 
    		{	
    			return _information;
    		}
            set
    		{
    			if(_information == value)
    			{
    				return;
    			}
    						
    			_information = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(INFORMATION);
    			 #endif
    		}
        }

        #endregion

        #region Navigation Properties
    
    		 
    		
        
        [IgnoreDataMember]
        public List<ServiceUnit> ServiceUnit {get; set;}

        #endregion

    }
}
