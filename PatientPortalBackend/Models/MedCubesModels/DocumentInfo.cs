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
    [DataContract(Name = "DocumentInfo", Namespace = "http://MedCubes.DocumentSystem.Server.Models")]
    public partial class DocumentInfo : DomainBaseModel 
    {
        #region Constants
    	public static readonly string CONTENT = "Content";
    	public static readonly string CUSTOMERKEY = "CustomerKey";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string DOCUMENTID = "DocumentId";
    	public static readonly string DOCUMENTKEY = "DocumentKey";
    	public static readonly string VERSION = "Version";
    	public static readonly string DOCUMENTTYPE = "DocumentType";
    	public static readonly string MIMETYPE = "MimeType";
    	public static readonly string PRIMARYIDENTIFIER = "PrimaryIdentifier";
    	public static readonly string SECONDARYIDENTIFIER = "SecondaryIdentifier";
    	public static readonly string DOCRELATION = "DocRelation";
    	public static readonly string STATUS = "Status";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string PASSWORD = "Password";
    	public static readonly string KEYWORDS = "KeyWords";
    	public static readonly string ISFINALIZED = "IsFinalized";
    	public static readonly string COMMENT = "Comment";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string CREATEDBYUSER = "CreatedByUser";
    	public static readonly string CREATEDBYUSERID = "CreatedByUserId";
    	public static readonly string CREATEDDATE = "CreatedDate";
    	public static readonly string TITLE = "Title";
    	public static readonly string EXTERNALREFERENCE = "ExternalReference";
    	public static readonly string EXTERNALREFERENCEMODEL = "ExternalReferenceModel";
    	public static readonly string ANNOTATIONPKID = "AnnotationPkId";
    	public static readonly string ISUNEDITABLE = "IsUneditable";
    	public static readonly string DOCUWAREID = "DocuwareId";
    	public static readonly string ISSENTBYMAIL = "IsSentByMail";
    	public static readonly string ISPRINTED = "IsPrinted";
        public static readonly string ISINTERNALLOCKED = "IsInternalLocked";
        public static readonly string EXTERNALDOCUMENTURL = "ExternalDocumentUrl";

        #endregion

        #region Constructor
        public DocumentInfo()
    	{	 
        }
        #endregion

        #region Primitive Properties
    	
    	private byte[] _content;
        
    	[DataMember]	
    	public  byte[] Content
        {    
            get 
    		{	
    			return _content;
    		}
            set
    		{
    			if(_content == value)
    			{
    				return;
    			}
    						
    			_content = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(CONTENT);
    			#endif
    		}
        }
    	
    	private System.Guid _customerKey;
        
    	[DataMember]	
    	public  System.Guid CustomerKey
        {    
            get 
    		{	
    			return _customerKey;
    		}
            set
    		{
    			if(_customerKey == value)
    			{
    				return;
    			}
    						
    			_customerKey = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(CUSTOMERKEY);
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
    	
    	private System.Guid _documentKey;
        
    	[DataMember]	
    	public  System.Guid DocumentKey
        {    
            get 
    		{	
    			return _documentKey;
    		}
            set
    		{
    			if(_documentKey == value)
    			{
    				return;
    			}
    						
    			_documentKey = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(DOCUMENTKEY);
    			#endif
    		}
        }
    	
    	private Nullable<int> _version;
        
    	[DataMember]	
    	public  Nullable<int> Version
        {    
            get 
    		{	
    			return _version;
    		}
            set
    		{
    			if(_version == value)
    			{
    				return;
    			}
    						
    			_version = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(VERSION);
    			#endif
    		}
        }
    	
    	private Nullable<int> _documentType;
        
    	[DataMember]	
    	public  Nullable<int> DocumentType
        {    
            get 
    		{	
    			return _documentType;
    		}
            set
    		{
    			if(_documentType == value)
    			{
    				return;
    			}
    						
    			_documentType = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(DOCUMENTTYPE);
    			#endif
    		}
        }
    	
    	private string _mimeType;
        
    	[DataMember]	
    	public  string MimeType
        {    
            get 
    		{	
    			return _mimeType;
    		}
            set
    		{
    			if(_mimeType == value)
    			{
    				return;
    			}
    						
    			_mimeType = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(MIMETYPE);
    			#endif
    		}
        }
    	
    	private string _primaryIdentifier;
        
    	[DataMember]	
    	public  string PrimaryIdentifier
        {    
            get 
    		{	
    			return _primaryIdentifier;
    		}
            set
    		{
    			if(_primaryIdentifier == value)
    			{
    				return;
    			}
    						
    			_primaryIdentifier = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(PRIMARYIDENTIFIER);
    			#endif
    		}
        }
    	
    	private string _secondaryIdentifier;
        
    	[DataMember]	
    	public  string SecondaryIdentifier
        {    
            get 
    		{	
    			return _secondaryIdentifier;
    		}
            set
    		{
    			if(_secondaryIdentifier == value)
    			{
    				return;
    			}
    						
    			_secondaryIdentifier = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(SECONDARYIDENTIFIER);
    			#endif
    		}
        }
    	
    	private string _docRelation;
        
    	[DataMember]	
    	public  string DocRelation
        {    
            get 
    		{	
    			return _docRelation;
    		}
            set
    		{
    			if(_docRelation == value)
    			{
    				return;
    			}
    						
    			_docRelation = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(DOCRELATION);
    			#endif
    		}
        }
    	
    	private Nullable<int> _status;
        
    	[DataMember]	
    	public  Nullable<int> Status
        {    
            get 
    		{	
    			return _status;
    		}
            set
    		{
    			if(_status == value)
    			{
    				return;
    			}
    						
    			_status = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(STATUS);
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
    	
    	private byte[] _password;
        
    	[DataMember]	
    	public  byte[] Password
        {    
            get 
    		{	
    			return _password;
    		}
            set
    		{
    			if(_password == value)
    			{
    				return;
    			}
    						
    			_password = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(PASSWORD);
    			#endif
    		}
        }
    	
    	private string _keyWords;
        
    	[DataMember]	
    	public  string KeyWords
        {    
            get 
    		{	
    			return _keyWords;
    		}
            set
    		{
    			if(_keyWords == value)
    			{
    				return;
    			}
    						
    			_keyWords = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(KEYWORDS);
    			#endif
    		}
        }
    	
    	private bool _isFinalized;
        
    	[DataMember]	
    	public  bool IsFinalized
        {    
            get 
    		{	
    			return _isFinalized;
    		}
            set
    		{
    			if(_isFinalized == value)
    			{
    				return;
    			}
    						
    			_isFinalized = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(ISFINALIZED);
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
    	
    	private string _createdByUser;
        
    	[DataMember]	
    	public  string CreatedByUser
        {    
            get 
    		{	
    			return _createdByUser;
    		}
            set
    		{
    			if(_createdByUser == value)
    			{
    				return;
    			}
    						
    			_createdByUser = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(CREATEDBYUSER);
    			#endif
    		}
        }
    	
    	private long _createdByUserId;
        
    	[DataMember]	
    	public  long CreatedByUserId
        {    
            get 
    		{	
    			return _createdByUserId;
    		}
            set
    		{
    			if(_createdByUserId == value)
    			{
    				return;
    			}
    						
    			_createdByUserId = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(CREATEDBYUSERID);
    			#endif
    		}
        }
    	
    	private Nullable<System.DateTimeOffset> _createdDate;
        
    	[DataMember]	
    	public  Nullable<System.DateTimeOffset> CreatedDate
        {    
            get 
    		{if(_createdDate == null) return null;
    				
    			#if SILVERLIGHT
    			  return _createdDate.Value.ToLocalTime();
    			#else
    			  return _createdDate;
    			#endif
    			}
            set
    		{
    			if (_createdDate == value && (value != null && _createdDate != null && value.Value.Offset == _createdDate.Value.Offset))
    			{
    				return;
    			}
    						
    			_createdDate = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(CREATEDDATE);
    			#endif
    		}
        }
    	
    	private string _title;
        
    	[DataMember]	
    	public  string Title
        {    
            get 
    		{	
    			return _title;
    		}
            set
    		{
    			if(_title == value)
    			{
    				return;
    			}
    						
    			_title = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(TITLE);
    			#endif
    		}
        }
    	
    	private string _externalReference;
        
    	[DataMember]	
    	public  string ExternalReference
        {    
            get 
    		{	
    			return _externalReference;
    		}
            set
    		{
    			if(_externalReference == value)
    			{
    				return;
    			}
    						
    			_externalReference = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(EXTERNALREFERENCE);
    			#endif
    		}
        }
    	
    	private string _externalReferenceModel;
        
    	[DataMember]	
    	public  string ExternalReferenceModel
        {    
            get 
    		{	
    			return _externalReferenceModel;
    		}
            set
    		{
    			if(_externalReferenceModel == value)
    			{
    				return;
    			}
    						
    			_externalReferenceModel = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(EXTERNALREFERENCEMODEL);
    			#endif
    		}
        }
    	
    	private Nullable<long> _annotationPkId;
        
    	[DataMember]	
    	public  Nullable<long> AnnotationPkId
        {    
            get 
    		{	
    			return _annotationPkId;
    		}
            set
    		{
    			if(_annotationPkId == value)
    			{
    				return;
    			}
    						
    			_annotationPkId = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(ANNOTATIONPKID);
    			#endif
    		}
        }
    	
    	private bool _isUneditable;
        
    	[DataMember]	
    	public  bool IsUneditable
        {    
            get 
    		{	
    			return _isUneditable;
    		}
            set
    		{
    			if(_isUneditable == value)
    			{
    				return;
    			}
    						
    			_isUneditable = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(ISUNEDITABLE);
    			#endif
    		}
        }
    	
    	private string _docuwareId;
        
    	[DataMember]	
    	public  string DocuwareId
        {    
            get 
    		{	
    			return _docuwareId;
    		}
            set
    		{
    			if(_docuwareId == value)
    			{
    				return;
    			}
    						
    			_docuwareId = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(DOCUWAREID);
    			#endif
    		}
        }
    	
    	private bool _isSentByMail;
        
    	[DataMember]	
    	public  bool IsSentByMail
        {    
            get 
    		{	
    			return _isSentByMail;
    		}
            set
    		{
    			if(_isSentByMail == value)
    			{
    				return;
    			}
    						
    			_isSentByMail = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(ISSENTBYMAIL);
    			#endif
    		}
        }
    	
    	private bool _isPrinted;
        
    	[DataMember]	
    	public  bool IsPrinted
        {    
            get 
    		{	
    			return _isPrinted;
    		}
            set
    		{
    			if(_isPrinted == value)
    			{
    				return;
    			}
    						
    			_isPrinted = value;
    		    #if SILVERLIGHT
    			  OnPropertyChanged(ISPRINTED);
    			#endif
    		}
        }

        private Nullable<bool> _isInternalLocked;
        
        [DataMember]
        public Nullable<bool> IsInternalLocked
        {
            get
            {
                return _isInternalLocked;
            }
            set
            {
                if (_isInternalLocked == value)
                {
                    return;
                }

                _isInternalLocked = value;
                #if SILVERLIGHT
    			  OnPropertyChanged(ISINTERNALLOCKED);
                #endif
            }
        }

        private string _externalDocumentUrl;
        
        [DataMember]
        public string ExternalDocumentUrl
        {
            get
            {
                return _externalDocumentUrl;
            }
            set
            {
                if (_externalDocumentUrl == value)
                {
                    return;
                }

                _externalDocumentUrl = value;
                #if SILVERLIGHT
    			  OnPropertyChanged(EXTERNALDOCUMENTURL);
                #endif
            }
        }

        #endregion

    }
}
