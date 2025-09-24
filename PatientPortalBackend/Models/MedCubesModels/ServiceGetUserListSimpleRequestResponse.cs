using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Requestclass for the service GetUserListSimple.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Framework.Services.RequestResponse.User")]
    public partial class ServiceGetUserListSimpleRequest : ServiceBaseRequest
    {
        [DataMember]
        public List<long> UserIds { get; set; }
    }   


	/// <summary>
	/// Responseclass for the service GetUserListSimple.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Framework.Services.RequestResponse.User")]	
    public partial class ServiceGetUserListSimpleResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<User> UserList  { get; set; }
    }   
}
