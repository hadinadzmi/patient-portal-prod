using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Attention!!!
    /// Place new functionality into separate partial class as this class-file will be recreated
    /// if tt procedure is executed again (your modifications would be lost)!
    /// </summary>
    [DataContract(Name = "PopupEntry", Namespace = "MedCubes.Framework.Models")]
    public partial class PopupEntry : DomainBaseModel 
    {  
        #region Constants
    	public static readonly string POPUPENTRYID = "PopupEntryId";
    	public static readonly string POPUPHEADERID = "PopupHeaderId";
    	public static readonly string POPUPKEY = "PopupKey";
    	public static readonly string SORTORDER = "SortOrder";
    	public static readonly string POPUPENTRYCODE = "PopupEntryCode";
    	public static readonly string TEXT = "Text";
    	public static readonly string DESCRIPTION = "Description";
    	public static readonly string ADDITIONALPARAMETERS = "AdditionalParameters";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string ICON = "Icon";
    	public static readonly string ISCUSTOMERENTRY = "IsCustomerEntry";
    	public static readonly string PKID = "PkId";
    	public static readonly string COLOR = "Color";

        #endregion

    
        #region Constructor
    
    	public PopupEntry()
    	{	 
    	
    	}
    	 
        #endregion

    	 
        #region Primitive Properties
    	
    	private System.Guid _popupEntryId;
        
    	[DataMember]	
    	public  System.Guid PopupEntryId
        {    
          get 
    	  {		
       		 return _popupEntryId;
    	  }	
          set
    	  {
    			if(_popupEntryId == value) return;	
    		   _popupEntryId = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(POPUPENTRYID);
    		   #endif
    	}
        }
    	
    	private System.Guid _popupHeaderId;
        
    	[DataMember]	
    	public  System.Guid PopupHeaderId
        {    
          get 
    	  {		
       		 return _popupHeaderId;
    	  }	
          set
    	  {
    			if(_popupHeaderId == value) return;	
    		   _popupHeaderId = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(POPUPHEADERID);
    		   #endif
    	}
        }
    	
    	private string _popupKey;
        
    	[DataMember]	
    	public  string PopupKey
        {    
          get 
    	  {		
       		 return _popupKey;
    	  }	
          set
    	  {
    			if(_popupKey == value) return;	
    		   _popupKey = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(POPUPKEY);
    		   #endif
    	}
        }
    	
    	private int _sortOrder;
        
    	[DataMember]	
    	public  int SortOrder
        {    
          get 
    	  {		
       		 return _sortOrder;
    	  }	
          set
    	  {
    			if(_sortOrder == value) return;	
    		   _sortOrder = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(SORTORDER);
    		   #endif
    	}
        }
    	
    	private int _popupEntryCode;
        
    	[DataMember]	
    	public  int PopupEntryCode
        {    
          get 
    	  {		
       		 return _popupEntryCode;
    	  }	
          set
    	  {
    			if(_popupEntryCode == value) return;	
    		   _popupEntryCode = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(POPUPENTRYCODE);
    		   #endif
    	}
        }
    	
    	private string _text;
        
    	[DataMember]	
    	public  string Text
        {    
          get 
    	  {		
       		 return _text;
    	  }	
          set
    	  {
    			if(_text == value) return;	
    		   _text = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(TEXT);
    		   #endif
    	}
        }
    	
    	private string _description;
        
    	[DataMember]	
    	public  string Description
        {    
          get 
    	  {		
       		 return _description;
    	  }	
          set
    	  {
    			if(_description == value) return;	
    		   _description = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(DESCRIPTION);
    		   #endif
    	}
        }
    	
    	private string _additionalParameters;
        
    	[DataMember]	
    	public  string AdditionalParameters
        {    
          get 
    	  {		
       		 return _additionalParameters;
    	  }	
          set
    	  {
    			if(_additionalParameters == value) return;	
    		   _additionalParameters = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(ADDITIONALPARAMETERS);
    		   #endif
    	}
        }
    	
    	private short _recordState;
        
    	[DataMember]	
    	public  short RecordState
        {    
          get 
    	  {		
       		 return _recordState;
    	  }	
          set
    	  {
    			if(_recordState == value) return;	
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
    			if(_rowVersion == value) return;	
    		   _rowVersion = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(ROWVERSION);
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
    			if(_icon == value) return;	
    		   _icon = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(ICON);
    		   #endif
    	}
        }
    	
    	private bool _isCustomerEntry;
        
    	[DataMember]	
    	public  bool IsCustomerEntry
        {    
          get 
    	  {		
       		 return _isCustomerEntry;
    	  }	
          set
    	  {
    			if(_isCustomerEntry == value) return;	
    		   _isCustomerEntry = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(ISCUSTOMERENTRY);
    		   #endif
    	}
        }
    	
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
    			if(_pkId == value) return;	
    		   _pkId = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(PKID);
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
    			if(_color == value) return;	
    		   _color = value;			 
    		   #if SILVERLIGHT
    		   OnPropertyChanged(COLOR);
    		   #endif
    	}
        }

        #endregion

     //   #region Navigation Properties
    
    		 
    		
      
    	//[JsonIgnore]
     //   public  Tenant Tenant
     //   {
     //       get; set; 
     //   }    

     //   #endregion

    }
}
