// this is to be used for the MedCubes API
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(Models.PatientAppointment))]
    public partial class ServiceGetPatientCalendarEntryListRequest : ServiceBaseRequest
    {
        //[DataMember]
        //public Models.PatientCalendarEntry PatientCalendarEntryRecord { get; set; }

        [DataMember]
        public Guid? PatientCalendarEntryId { get; set; }

        [DataMember]
        public Guid? PatientId { get; set; }

        [DataMember]
        public List<Guid> PatientIdList { get; set; }

        [DataMember]
        public List<long> ServiceUnitIdList { get; set; }

        [DataMember]
        public List<int> FilterTypeList { get; set; }

        [DataMember]
        public DateTimeOffset? DateTimeFrom { get; set; }

        [DataMember]
        public DateTimeOffset? DateTimeTo { get; set; }

        [DataMember]
        public List<DateTimeOffsetRange> TimeRangeList { get; set; }

        [DataMember]
        public bool ReadResourceIdList { get; set; }

        [DataMember]
        public List<Guid> ResourceIdList { get; set; }

        [DataMember]
        public List<Guid> ResourceUserIdList { get; set; }

        [DataMember]
        public List<int> PlanningStateList { get; set; }

        [DataMember]
        public bool LoadPatientName { get; set; }

        [DataMember]
        public bool FilterForManualReminderOnly { get; set; }

        [DataMember]
        public long? FilterResourceUserId { get; set; }

        [DataMember]
        public long? FilterCreateUserId { get; set; }

        [DataMember]
        public Guid? LinkId { get; set; }
    }

    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.PatientCalendarEntry")]
    [KnownType(typeof(Models.PatientAppointment))]
    public partial class ServiceGetPatientCalendarEntryListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<PatientCalendarEntry> PatientCalendarEntryList { get; set; }
    }
}
