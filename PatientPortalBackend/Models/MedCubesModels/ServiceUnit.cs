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
    [DataContract(Name = "ServiceUnit", Namespace = "www.Ahcs.co/MedCubes/models")]
    public partial class ServiceUnit : DomainBaseModel 
    {
        #region Constants
    	public static readonly string SERVICEUNITID = "ServiceUnitId";
    	public static readonly string CUSTOMERID = "CustomerId";
    	public static readonly string TENANTID = "TenantId";
    	public static readonly string RECORDSTATE = "RecordState";
    	public static readonly string ROWVERSION = "RowVersion";
    	public static readonly string SERVICEUNITKEY = "ServiceUnitKey";
    	public static readonly string SHORTNAME = "ShortName";
    	public static readonly string NAME = "Name";
    	public static readonly string ADMISSIONTYPES = "AdmissionTypes";
    	public static readonly string DEPARTMENTID = "DepartmentId";
    	public static readonly string DESCRIPTION = "Description";
    	public static readonly string VALIDFROM = "ValidFrom";
    	public static readonly string VALIDUNTIL = "ValidUntil";
    	public static readonly string TASKID = "TaskId";
    	public static readonly string MAPPEDSERVICEUNITID = "MappedServiceUnitId";
    	public static readonly string ISINVALIDFORSERVICEBOOKING = "IsInvalidForServiceBooking";
    	public static readonly string ADDITIONALKEY = "AdditionalKey";
    	public static readonly string ADDITIONALKEY2 = "AdditionalKey2";
    	public static readonly string ZSRNUMBER = "ZsrNumber";
    	public static readonly string GLNNUMBER = "GlnNumber";
    	public static readonly string VATNUMBER = "VatNumber";
        public static readonly string UIDNUMBER = "UidNumber";
        public static readonly string IBAN = "Iban";
        public static readonly string CUSTOMERIDENTIFICATIONNUMBERUIDNUMBER = "CustomerIdentificationNumber";
        public static readonly string ACCOUNTRECIPIENT = "AccountRecipient";

        #endregion

        #region Constructor
    	public ServiceUnit()
    	{	 
        	   ExaminationUnit = new List<ExaminationUnit>();
        	   Room = new List<Room>();
        }
        #endregion

    	 
        #region Primitive Properties
    	
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
    	
    	private string _serviceUnitKey;
    		
        
    	[DataMember]		
    	public  string ServiceUnitKey
        {    
            get 
    		{	
    			return _serviceUnitKey;
    		}
            set
    		{
    			if(_serviceUnitKey == value)
    			{
    				return;
    			}
    						
    			_serviceUnitKey = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(SERVICEUNITKEY);
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
    	
    	private string _admissionTypes;
    		
        
    	[DataMember]		
    	public  string AdmissionTypes
        {    
            get 
    		{	
    			return _admissionTypes;
    		}
            set
    		{
    			if(_admissionTypes == value)
    			{
    				return;
    			}
    						
    			_admissionTypes = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ADMISSIONTYPES);
    			 #endif
    		}
        }
    	
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
    			if(_description == value)
    			{
    				return;
    			}
    						
    			_description = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(DESCRIPTION);
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
    	
    	private Nullable<System.Guid> _taskId;
    		
        
    	[DataMember]		
    	public  Nullable<System.Guid> TaskId
        {    
            get 
    		{	
    			return _taskId;
    		}
            set
    		{
    			if(_taskId == value)
    			{
    				return;
    			}
    						
    			_taskId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(TASKID);
    			 #endif
    		}
        }
    	
    	private Nullable<long> _mappedServiceUnitId;
    		
        
    	[DataMember]		
    	public  Nullable<long> MappedServiceUnitId
        {    
            get 
    		{	
    			return _mappedServiceUnitId;
    		}
            set
    		{
    			if(_mappedServiceUnitId == value)
    			{
    				return;
    			}
    						
    			_mappedServiceUnitId = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(MAPPEDSERVICEUNITID);
    			 #endif
    		}
        }
    	
    	private bool _isInvalidForServiceBooking;
    		
        
    	[DataMember]		
    	public  bool IsInvalidForServiceBooking
        {    
            get 
    		{	
    			return _isInvalidForServiceBooking;
    		}
            set
    		{
    			if(_isInvalidForServiceBooking == value)
    			{
    				return;
    			}
    						
    			_isInvalidForServiceBooking = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ISINVALIDFORSERVICEBOOKING);
    			 #endif
    		}
        }
    	
    	private string _additionalKey;
    		
        
    	[DataMember]		
    	public  string AdditionalKey
        {    
            get 
    		{	
    			return _additionalKey;
    		}
            set
    		{
    			if(_additionalKey == value)
    			{
    				return;
    			}
    						
    			_additionalKey = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ADDITIONALKEY);
    			 #endif
    		}
        }
    	
    	private string _additionalKey2;
    		
        
    	[DataMember]		
    	public  string AdditionalKey2
        {    
            get 
    		{	
    			return _additionalKey2;
    		}
            set
    		{
    			if(_additionalKey2 == value)
    			{
    				return;
    			}
    						
    			_additionalKey2 = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ADDITIONALKEY2);
    			 #endif
    		}
        }
    	
    	private string _zsrNumber;
    		
        
    	[DataMember]		
    	public  string ZsrNumber
        {    
            get 
    		{	
    			return _zsrNumber;
    		}
            set
    		{
    			if(_zsrNumber == value)
    			{
    				return;
    			}
    						
    			_zsrNumber = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(ZSRNUMBER);
    			 #endif
    		}
        }
    	
    	private string _glnNumber;
    		
        
    	[DataMember]		
    	public  string GlnNumber
        {    
            get 
    		{	
    			return _glnNumber;
    		}
            set
    		{
    			if(_glnNumber == value)
    			{
    				return;
    			}
    						
    			_glnNumber = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(GLNNUMBER);
    			 #endif
    		}
        }
    	
    	private string _vatNumber;
    		
        
    	[DataMember]		
    	public  string VatNumber
        {    
            get 
    		{	
    			return _vatNumber;
    		}
            set
    		{
    			if(_vatNumber == value)
    			{
    				return;
    			}
    						
    			_vatNumber = value;
    			 #if SILVERLIGHT
    			 OnPropertyChanged(VATNUMBER);
    			 #endif
    		}
        }

        private string _uidNumber;
    		
        
        [DataMember]		
        public  string UidNumber
        {    
            get 
            {	
                return _uidNumber;
            }
            set
            {
                if(_uidNumber == value)
                {
                    return;
                }
    						
                _uidNumber = value;
                 #if SILVERLIGHT
    			 OnPropertyChanged(UIDNUMBER);
                 #endif
            }
        }

        private string _iban;
    		
        
        [DataMember]		
        public  string Iban
        {    
            get 
            {	
                return _iban;
            }
            set
            {
                if(_iban == value)
                {
                    return;
                }
    						
                _iban = value;
#if SILVERLIGHT
    			 OnPropertyChanged(IBAN);
#endif
            }
        }

        private string _customerIdentificationNumber;
    		
        
        [DataMember]		
        public  string CustomerIdentificationNumber
        {    
            get 
            {	
                return _customerIdentificationNumber;
            }
            set
            {
                if(_customerIdentificationNumber == value)
                {
                    return;
                }
    						
                _customerIdentificationNumber = value;
#if SILVERLIGHT
    			 OnPropertyChanged(CUSTOMERIDENTIFICATIONNUMBERUIDNUMBER);
#endif
            }
        }

        private string _accountRecipient;
    		
        
        [DataMember]		
        public  string AccountRecipient
        {    
            get 
            {	
                return _accountRecipient;
            }
            set
            {
                if(_accountRecipient == value)
                {
                    return;
                }
    						
                _accountRecipient = value;
#if SILVERLIGHT
    			 OnPropertyChanged(ACCOUNTRECIPIENT);
#endif
            }
        }


        #endregion

        #region Navigation Properties
    
    		 
    		
      
    	[IgnoreDataMember]
        public  Department Department
        {
            get; set; 
    
        }    
    
    		 
    		
        
        [IgnoreDataMember]
        public List<ExaminationUnit> ExaminationUnit {get; set;}
    
    		 
    		
        
        [IgnoreDataMember]
        public List<Room> Room {get; set;}

        #endregion

    }
}
