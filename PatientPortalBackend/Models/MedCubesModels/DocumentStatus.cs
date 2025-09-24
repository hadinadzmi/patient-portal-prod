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
    [DataContract(Name = "DocumentStatus", Namespace = "http://MedCubes.DocumentSystem.Server.Models")]
    public partial class DocumentStatus : DomainBaseModel 
    {
        #region Constants
    	public static readonly string PKID = "PkId";
    	public static readonly string DOCUMENTID = "DocumentId";
    	public static readonly string STATUSTYPE = "StatusType";
    	public static readonly string CHANGINGUSER = "ChangingUser";
    	public static readonly string DATEOFCHANGE = "DateOfChange";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string CHANGINGUSERID = "ChangingUserId";

        #endregion

        #region Constructor
    	public DocumentStatus()
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
    	
    	private long _documentId;
        
    	[DataMember]	
    	public  long DocumentId
        {    
            get 
    		{	
    			return _documentId;
    		}
            set
    		{
    			if(_documentId == value)
    			{
    				return;
    			}
    						
    			_documentId = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(DOCUMENTID);
    			#endif
    		}
        }
    	
    	private short _statusType;
        
    	[DataMember]	
    	public  short StatusType
        {    
            get 
    		{	
    			return _statusType;
    		}
            set
    		{
    			if(_statusType == value)
    			{
    				return;
    			}
    						
    			_statusType = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(STATUSTYPE);
    			#endif
    		}
        }
    	
    	private string _changingUser;
        
    	[DataMember]	
    	public  string ChangingUser
        {    
            get 
    		{	
    			return _changingUser;
    		}
            set
    		{
    			if(_changingUser == value)
    			{
    				return;
    			}
    						
    			_changingUser = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(CHANGINGUSER);
    			#endif
    		}
        }
    	
    	private System.DateTimeOffset _dateOfChange;
        
    	[DataMember]	
    	public  System.DateTimeOffset DateOfChange
        {    
            get 
    		{		
    			#if SILVERLIGHT
    			  return _dateOfChange.ToLocalTime();
    			#else
    			  return _dateOfChange;
    			#endif
    		}
            set
    		{
    			if (_dateOfChange == value && value.Offset == _dateOfChange.Offset)
    			{
    				return;
    			}
    						
    			_dateOfChange = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(DATEOFCHANGE);
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
    	
    	private long _changingUserId;
        
    	[DataMember]	
    	public  long ChangingUserId
        {    
            get 
    		{	
    			return _changingUserId;
    		}
            set
    		{
    			if(_changingUserId == value)
    			{
    				return;
    			}
    						
    			_changingUserId = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(CHANGINGUSERID);
    			#endif
    		}
        }

        #endregion

    }
}
