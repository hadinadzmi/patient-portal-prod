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
    public class ServiceMedimaxDeletePatientCalendarEntryRequest : ServiceBaseRequest
    {
        [DataMember]
        public long PkIdToDelete { get; set; }

        [DataMember]
        public bool DeleteRemainingSeriesEntries { get; set; }

        //[DataMember]
        //public string PatientCalendarEntryId { get; set; }

        [DataMember]
        public string CancelReason { get; set; }
    }

    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(PatientCalendarEntry))]
    public class ServiceMedimaxDeletePatientCalendarEntryResponse : ServiceBaseResponse
    {
        [DataMember]
        public PatientCalendarEntry PatientCalendarEntryRecord { get; set; }
    }
}
