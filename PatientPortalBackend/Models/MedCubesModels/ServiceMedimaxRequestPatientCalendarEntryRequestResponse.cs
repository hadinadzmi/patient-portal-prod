using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Request class for the service MedimaxRequestPatientCalendarEntry.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(PatientCalendarEntry))]
    public class ServiceMedimaxRequestPatientCalendarEntryRequest : ServiceBaseRequest
    {
        [DataMember]
        public List<PatientCalendarEntry> PatientCalendarEntryList { get; set; }
    }

    /// <summary>
    /// Response class for the service MedimaxRequestPatientCalendarEntry.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(PatientCalendarEntry))]
    public class ServiceMedimaxRequestPatientCalendarEntryResponse : ServiceBaseResponse
    {
        public List<PatientCalendarEntry> PatientCalendarEntryList { get; set; }
    }
}
