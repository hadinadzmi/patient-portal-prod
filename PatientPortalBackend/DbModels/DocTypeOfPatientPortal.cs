using System;
using System.Collections.Generic;

namespace PatientPortalBackend.DbModels;

public partial class DocTypeOfPatientPortal
{
    public long PkId { get; set; }

    public long CustomerId { get; set; }

    public long TenantId { get; set; }

    public byte RecordState { get; set; }

    public byte[] RowVersion { get; set; }

    public bool IsDirectViewAllowed { get; set; }

    public long DocumentTypePkId { get; set; }
}
