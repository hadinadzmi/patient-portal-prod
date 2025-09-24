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
    [DataContract(Name = "PatientCalendarEntryResourceRelationship", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class PatientCalendarEntryResourceRelationship : DomainBaseModel 
    {
        #region Constants
    	public static readonly string PKID = "PkId";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string PATIENTCALENDARENTRYID = "PatientCalendarEntryId";
    	public static readonly string RESOURCEID = "ResourceId";

        #endregion

        #region Constructor
    	public PatientCalendarEntryResourceRelationship()
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
    	
    	private System.Guid _patientCalendarEntryId;
        
    	[DataMember]	
    	public  System.Guid PatientCalendarEntryId
        {    
            get 
    		{	
    			return _patientCalendarEntryId;
    		}
            set
    		{
    			if(_patientCalendarEntryId == value)
    			{
    				return;
    			}
    						
    			_patientCalendarEntryId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(PATIENTCALENDARENTRYID);
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

        #endregion

    }
}
