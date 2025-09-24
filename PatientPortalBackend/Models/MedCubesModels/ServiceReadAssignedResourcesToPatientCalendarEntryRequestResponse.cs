using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
	/// <summary>
    /// Requestclass for the service ReadAssignedResourcesToPatientCalendarEntry.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.Scheduler")]
    [KnownType(typeof(PatientCalendarEntryResourceRelationship))]
    public partial class ServiceReadAssignedResourcesToPatientCalendarEntryRequest : ServiceBaseRequest
    {
        [DataMember]
        public PatientCalendarEntryResourceRelationship AssignedResourcesRecord { get; set; }

        [DataMember]
        public List<Guid> PatientCalendarEntryIdList { get; set; }

        [DataMember]
        public List<Guid> ResourceIdList { get; set; }

    }   


	/// <summary>
    /// Responseclass for the service ReadAssignedResourcesToPatientCalendarEntry.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.Scheduler")]
    [KnownType(typeof(PatientCalendarEntryResourceRelationship))]
    public partial class ServiceReadAssignedResourcesToPatientCalendarEntryResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<PatientCalendarEntryResourceRelationship> AssignedResourcesList { get; set; }

        [DataMember]
        public List<long> AlsoDeletedPkIdList { get; set; }

    }   
}
