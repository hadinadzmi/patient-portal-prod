using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Requestclass for the service CreatePatientCalendarEntry.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(PatientCalendarEntry))]
    public partial class ServiceCreatePatientCalendarEntryRequest : ServiceBaseRequest
    {
        [DataMember]
        public List<PatientCalendarEntry> PatientCalendarEntryList { get; set; }

        [DataMember]
        public bool SkipCreateUserAssignment { get; set; }
    }

    /// <summary>
    /// Responseclass for the service CreatePatientCalendarEntry.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]	
    [KnownType(typeof(PatientCalendarEntry))]
    public partial class ServiceCreatePatientCalendarEntryResponse : ServiceBaseResponse
    {        
        [DataMember]
        public List<PatientCalendarEntry> PatientCalendarEntryList { get; set; }
    }
}
