using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(PatientCalendarEntry))]
    public class ServiceMedimaxUpdatePatientCalendarEntryRequest : ServiceBaseRequest
    {
        [DataMember]
        public long PkIdToUpdate { get; set; }

        [DataMember]
        public Guid PatientCalendarEntryID { get; set; }

        [DataMember]
        public DateTimeOffset StartDateTime { get; set; }

        [DataMember]
        public DateTimeOffset? EndDateTime { get; set; }

        [DataMember]
        public string UpdateReason { get; set; }
    }

    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(PatientCalendarEntry))]
    public class ServiceMedimaxUpdatePatientCalendarEntryResponse : ServiceBaseResponse
    {
    }
}
