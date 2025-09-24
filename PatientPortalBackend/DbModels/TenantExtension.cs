using System;
using System.Collections.Generic;

namespace PatientPortalBackend.DbModels;

public partial class TenantExtension
{
    public long PkId { get; set; }

    public long CustomerId { get; set; }

    public long TenantId { get; set; }

    public byte RecordState { get; set; }

    public byte[] RowVersion { get; set; }

    public Guid TenantGuid { get; set; }

    public string MedCubesIisUrl { get; set; }

    public string ResolvedUserName { get; set; }

    public string PatientPortalUserName { get; set; }

    public string Email { get; set; }
}
