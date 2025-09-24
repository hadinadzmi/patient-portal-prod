using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
	/// <summary>
	/// Request for user authentication, includes username and password to check.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
	public class ServiceSendMailRequest : ServiceBaseRequest
	{
        [DataMember]
        public MailContainer MailContainer { get; set; }
	}

    /// <summary>
    /// Returns a valid user, the authentication token and the possible customer / tenants and profile selection for the user.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceSendMailResponse : ServiceBaseResponse
    {
    } 
}
