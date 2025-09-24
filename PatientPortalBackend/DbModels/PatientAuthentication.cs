using System;
using System.Collections.Generic;

namespace PatientPortalBackend.DbModels;

public partial class PatientAuthentication
{
    public long PkId { get; set; }

    public long CustomerId { get; set; }

    public long TenantId { get; set; }

    public byte RecordState { get; set; }

    public byte[] RowVersion { get; set; }

    public string PatientHash { get; set; }

    public int TryCount { get; set; }

    public DateTime DateTried { get; set; }

    public Guid? TenantGuid { get; set; }

    public string PatientIdNumber { get; set; }

    public string Email { get; set; }

    public DateTime? DateOfBirth { get; set; }
}
