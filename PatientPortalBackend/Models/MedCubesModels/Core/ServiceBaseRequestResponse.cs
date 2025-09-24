using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System;

namespace PatientPortalBackend.Models.MedCubesModels.Core
{
    /// <summary>
    /// Interface for properties each web service request contains.
    /// The class <see cref="ServiceBaseRequest"/> implements all these properties.
    /// </summary>
    public interface IServiceBaseRequest
    {
        /// <summary>
        /// Gets or sets the transaction id of the web service call.
        /// Can be used on the client to handle multiple service-responses of the same proxy.
        /// </summary>
        Guid TransactionId { get; set; }
        /// <summary>
        /// Indicates if caller wants to have the object back after update/save
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [send object back after save]; otherwise, <c>false</c>.
        /// </value>
        bool SendObjectBackAfterSave { get; set; }

        /// <summary>
        /// The TenantId of the requesing client
        /// </summary>
        /// <value>
        /// The client tenant id.
        /// </value>
        long ClientTenantId { get; set; }

        /// <summary>
        /// The CustomerId of the requesting client.
        /// </summary>
        /// <value>
        /// The client customer id.
        /// </value>
        long ClientCustomerId { get; set; }

        /// <summary>
        /// Recordstate to be considered
        /// </summary>
        /// <value>
        /// The state of the record.
        /// </value>
        int RecordState { get; set; }

        /// <summary>
        /// The user calling the service
        /// </summary>
        /// <value>
        /// The client user id.
        /// </value>
        long ClientUserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the client user.
        /// </summary>
        /// <value>
        /// The name of the client user.
        /// </value>
        string ClientUserName { get; set; }

        /// <summary>
        /// The currently active profile of the user calling the service
        /// </summary>
        /// <value>
        /// The client profile id.
        /// </value>
        Guid ClientProfileId { get; set; }

        /// <summary>
        /// The machineId calling the service
        /// </summary>
        /// <value>
        /// The client machine id.
        /// </value>
        string ClientMachineId { get; set; }

        /// <summary>
        /// Gets or sets the client log level.
        /// </summary>
        /// <value>
        /// The client log level.
        /// </value>
        int ClientLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the client token.
        /// </summary>
        /// <value>
        /// The client token.
        /// </value>
        string ClientToken { get; set; }

        /// <summary>
        /// Set/Get property for the searchCriteria
        /// </summary>
        string SearchFilter { get; set; }

        /// <summary>
        /// This flags indicates if the service to start should join an ambient transaction.
        /// If set to true, the transactionscope of the following transaction will be set
        /// to TransactionScope.Required, if set to false TransactionScope.RequiresNew will be set.
        /// </summary>
        bool IsChildTransaction { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this request is s test request.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is test request; otherwise, <c>false</c>.
        /// </value>
        bool IsTestRequest { get; set; }


        /// <summary>
        /// Indicates the number of objects to fetch from the database
        /// </summary>
        int Take { get; set; }


        /// <summary>
        /// Indicates the number of items to skip during database access
        /// </summary>
        int Skip { get; set; }

        /// <summary>
        /// Indicates the table of the service, which initialized the call of the subservice.
        /// </summary>
        string ParentTable { get; set; }

        /// <summary>
        /// Indicates the key of the parenttable of the service, which initialized the call of the subservice.
        /// </summary>
        string ParentKey { get; set; }

        /// <summary>
        /// Indicates the primary identifier of the service, which initialized the call of the subservice.
        /// </summary>
        string PrimaryIdentifier { get; set; }

        /// <summary>
        /// Indicates the secondary identifier of the service, which initialized the call of the subservice.
        /// </summary>

        string SecondaryIdentifier { get; set; }

        /// <summary>
        /// This property when set to true will indicate any service that in case of a ConcurrencyException the 
        /// client data will overwrite the changes made in the meantime on the server for a certain record.
        /// </summary>
        bool ClientWins { get; set; }

        long CaseDataUniqueId4Refresh { get; set; }
        Guid PatientId4Refresh { get; set; }

        /// <summary>
        /// Indicates the current language of the client (of the logged-in user).
        /// </summary>
        string ClientLanguage { get; set; }

        Guid? SourceAppId { get; set; }

        Guid CustomerKey { get; set; }

        long WorkingSuId { get; set; }

        long? WorkingExamUnitId { get; set; }

        string ClientDecimalMark { get; set; }

        bool NoTransactionForRead { get; set; }

        Guid MedCubesInstanceId { get; set; }
    }

    /// <summary>
    /// This class is holds the input parameter.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf/Messages")]
    public partial class ServiceBaseRequest : IServiceBaseRequest
    {
        private bool _sendObjectBackAfterSave = true;
        /// <summary>
        /// Indicates if caller wants to have the object back after update/save
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [send object back after save]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool SendObjectBackAfterSave
        {
            get { return _sendObjectBackAfterSave; }
            set { _sendObjectBackAfterSave = value; }
        }

        /// <summary>
        /// The TenantId of the requesing client
        /// </summary>
        /// <value>
        /// The client tenant id.
        /// </value>
        [DataMember]
        public long ClientTenantId { get; set; }

        /// <summary>
        /// The CustomerId of the requesting client.
        /// </summary>
        /// <value>
        /// The client customer id.
        /// </value>
        [DataMember]
        public long ClientCustomerId { get; set; }

        /// <summary>
        /// Recordstate to be considered
        /// </summary>
        /// <value>
        /// The state of the record.
        /// </value>
        [DataMember]
        public int RecordState { get; set; }

        /// <summary>
        /// The user calling the service
        /// </summary>
        /// <value>
        /// The client user id.
        /// </value>
        [DataMember]
        public long ClientUserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the client user.
        /// </summary>
        /// <value>
        /// The name of the client user.
        /// </value>
        [DataMember]
        public string ClientUserName { get; set; }

        /// <summary>
        /// Gets or sets the id of the current wcf transaction.
        /// </summary>
        /// <value>
        /// The id of the wcf transaction.
        /// </value>
        [DataMember]
        public Guid TransactionId { get; set; }

        /// <summary>
        /// The currently active profile of the user calling the service
        /// </summary>
        /// <value>
        /// The client profile id.
        /// </value>
        [DataMember]
        public Guid ClientProfileId { get; set; }


        /// <summary>
        /// The machineId calling the service
        /// </summary>
        /// <value>
        /// The client machine id.
        /// </value>
        [DataMember]
        public string ClientMachineId { get; set; }

        /// <summary>
        /// Gets or sets the client log level.
        /// </summary>
        /// <value>
        /// The client log level.
        /// </value>
        [DataMember]
        public int ClientLogLevel { get; set; }

        /// <summary>
        /// Gets or sets the client token.
        /// </summary>
        /// <value>
        /// The client token.
        /// </value>
        [DataMember]
        public string ClientToken { get; set; }

        /// <summary>
        /// Set/Get property for the searchCriteria
        /// </summary>
        [DataMember]
        public string SearchFilter { get; set; }

        [DataMember]
        public bool IsChildTransaction { get; set; }

        [DataMember]
        public string ClientLanguage { get; set; }

        [DataMember]
        public Guid? SourceAppId { get; set; }

        [DataMember]
        public long WorkingSuId { get; set; }

        [DataMember]
        public long? WorkingExamUnitId { get; set; }

        [DataMember]
        public string ClientDecimalMark { get; set; }

        [DataMember]
        public bool NoTransactionForRead { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this request is s test request.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is test request; otherwise, <c>false</c>.
        /// </value>
        public bool IsTestRequest { get; set; }


        private int _take = 1000;
        [DataMember]
        public int Take
        {
            get { return _take <= 0 ? 1000 : _take; }
            set
            {
                if (value <= 0)
                {
                    _take = 1000;
                }
                _take = value;
            }
        }

        [DataMember]
        public int Skip { get; set; }

        /// <summary>
        /// Indicates the table of the service, which initialized the call of the subservice.
        /// </summary>
        [DataMember]
        public string ParentTable { get; set; }

        /// <summary>
        /// Indicates the key of the parenttable of the service, which initialized the call of the subservice.
        /// </summary>
        [DataMember]
        public string ParentKey { get; set; }

        /// <summary>
        /// Indicates the primary identifier of the service, which initialized the call of the subservice.
        /// </summary>
        [DataMember]
        public string PrimaryIdentifier { get; set; }

        /// <summary>
        /// Indicates the secondary identifier of the service, which initialized the call of the subservice.
        /// </summary>
        [DataMember]
        public string SecondaryIdentifier { get; set; }

        [DataMember]
        public bool ClientWins { get; set; }

        [DataMember]
        public Guid CustomerKey { get; set; }

        [DataMember]
        public Guid MedCubesInstanceId { get; set; }

        // Used for refreshLogic
        [DataMember]
        public long CaseDataUniqueId4Refresh { get; set; }

        // Used for refreshLogic
        [DataMember]
        public Guid PatientId4Refresh { get; set; }
    }

    /// <summary>
    /// Base interface for the response classes.
    /// </summary>
    public interface IServiceBaseResponse
    {
        /// <summary>
        /// This property represents the error that has happened and has to be filled by the service.
        /// If the service is sucessful, the Errorcode is only filled in case of not successful processing of the service
        /// and starts with a letter (error reason abbreviation), followed by a code.
        /// E.g. 
        /// T500 - (T)echnical error -code 500 - EntityConnecton not available
        /// B100 - (B)usiness logic error - code 100 - DB Concurrency Exception
        /// 
        /// The meaning of the codes have to be made public by the serviceprovider.
        /// </summary>
        string ErrorCode { get; set; }

        /// <summary>
        /// This property holds the information about errors in the model.
        /// </summary>
        ModelValidationResult ModelValidationResult { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IServiceBaseResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        bool Success { get; set; }

        /// <summary>
        /// Gets or sets the service messages.
        /// </summary>
        /// <value>
        /// The service messages.
        /// </value>
        List<string> ServiceMessages { get; set; }

        /// <summary>
        /// Returns the number of total available records for a given searchcriteria
        /// </summary>
        /// <value>
        /// The service messages.
        /// </value>
        long RecordsAvailable { get; set; }

        /// <summary>
        /// Imports the errors from exception.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="exception">The exception.</param>
        void ImportErrorsFromException(string errorCode, Exception exception);

        /// <summary>
        /// This methods add a number of strings to the collection
        /// </summary>
        /// <param name="textMessage">The text message.</param>
        void AddMessageText(params string[] textMessage);

        /// <summary>
        /// Gets or sets the transaction id.
        /// </summary>
        /// <value>
        /// The transaction id.
        /// </value>
        Guid TransactionId { get; set; }

#if SILVERLIGHT
        object GetProperty(string propertyName);
#endif
        //string ConcurrencyObject { get; set; }

    }

    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf/Messages")]
    [ZeroFormatter.ZeroFormattable]
    public class ServiceBaseResponse : IServiceBaseResponse
    {
        /// <summary>
        /// This property represents the error that has happened and has to be filled by the service.
        /// If the service is sucessful, the Errorcode is only filled in case of not successful processing of the service
        /// and starts with a letter (error reason abbreviation), followed by a code.
        /// E.g. 
        /// T500 - (T)echnical error -code 500 - EntityConnecton not available
        /// B100 - (B)usiness logic error - code 100 - DB Concurrency Exception
        /// 
        /// The meaning of the codes have to be made public by the serviceprovider.
        /// </summary>
        //[DataMember]
        //public string ConcurrencyObject { get; set; }

        [DataMember]
        [ZeroFormatter.Index(0)]
        public virtual string ErrorCode { get; set; }

        private ModelValidationResult _modelValidationResult;
        [ZeroFormatter.Index(1)]
        [DataMember]
        public virtual ModelValidationResult ModelValidationResult
        {
            get
            {
                if (_modelValidationResult == null)
                    _modelValidationResult = new ModelValidationResult();
                return _modelValidationResult;
            }
            set { _modelValidationResult = value; }
        }

        [DataMember]
        [ZeroFormatter.Index(2)]
        public virtual bool Success { get; set; }

        private List<string> _serviceMessages;
        [DataMember]
        [ZeroFormatter.Index(3)]
        public virtual List<string> ServiceMessages
        {
            get
            {
                if (_serviceMessages == null)
                    _serviceMessages = new List<string>();

                return _serviceMessages;
            }
            set
            {
                _serviceMessages = value;
            }
        }

        [ZeroFormatter.Index(4)]
        [DataMember]
        public virtual Guid TransactionId { get; set; }

        public ServiceBaseResponse()
        {
        }

        /// <summary>
        /// Returns the number of total available records for a given searchcriteria
        /// </summary>
        /// <value>
        /// The service messages.
        /// </value>
        [DataMember]
        [ZeroFormatter.Index(5)]
        public virtual long RecordsAvailable { get; set; }

        public void ImportErrorsFromException(string errorCode, Exception exception)
        {
            ServiceMessages = new List<string>();
            ModelValidationResult = new ModelValidationResult();
            Success = false;
            ErrorCode = errorCode;
            ServiceMessages.Add(exception.Message);
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                ServiceMessages.Add(exception.Message);
            }
        }

        public void AddMessageText(params string[] textMessage)
        {
            foreach (var text in textMessage)
            {
                ServiceMessages.Add(text);
            }
        }

    }
}
