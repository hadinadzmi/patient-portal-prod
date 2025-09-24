using System;
using System.Collections.Generic;

namespace PatientPortalBackend.DbModels;

public partial class ResourceOfPatientPortal
{
    public long PkId { get; set; }

    public long CustomerId { get; set; }

    public long TenantId { get; set; }

    public byte RecordState { get; set; }

    public byte[] RowVersion { get; set; }

    public bool OnlySendEmail { get; set; }

    public string Email { get; set; }

    public Guid ResourceId { get; set; }
}
