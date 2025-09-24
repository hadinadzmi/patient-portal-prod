using System;
using System.Collections.Generic;

namespace PatientPortalBackend.DbModels;

public partial class AppointmentRequestCount
{
    public long PkId { get; set; }

    public long CustomerId { get; set; }

    public long TenantId { get; set; }

    public byte RecordState { get; set; }

    public byte[] RowVersion { get; set; }

    public bool IsIdentified { get; set; }

    public DateOnly DateRequested { get; set; }

    public int RequestCount { get; set; }

    public Guid? PatientId { get; set; }

    public string HardwareId { get; set; }

    public string PatientHash { get; set; }
}
