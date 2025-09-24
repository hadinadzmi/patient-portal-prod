using System.Collections.Generic;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Request for user authentication, includes username and password to check.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    [KnownType(typeof(ServiceUserAuthenticationRequest))]
    [KnownType(typeof(ServiceBaseRequest))]
	public class ServiceUserAuthenticationRequest : ServiceBaseRequest
	{
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public byte[] Password { get; set; }

        [DataMember]
        public bool UseAdForLogin { get; set; }

        [DataMember]
        public bool NoPasswordExpirationCheck { get; set; }
    }

    /// <summary>
    /// Returns a valid user, the authentication token and the possible customer / tenants and profile selection for the user.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceUserAuthenticationResponse : ServiceBaseResponse
    {
        [DataMember]
        public string AuthenticationToken { get; set; }

        [DataMember]
        public User User { get; set; }

        [DataMember]
        public List<Customer> CustomerList { get; set; }

        [DataMember]
        public List<Tenant> TenantList { get; set; }

        [DataMember]
        public List<Profile> ProfileList { get; set; }

        [DataMember]
        public List<UiDesktop> DesktopList { get; set; }
    }  
}
