using System;
using System.Collections.Generic;

namespace PatientPortalBackend.DbModels;

public partial class PatientExtension
{
    public long PkId { get; set; }

    public long CustomerId { get; set; }

    public long TenantId { get; set; }

    public byte RecordState { get; set; }

    public byte[] RowVersion { get; set; }

    public Guid PatientId { get; set; }

    public bool IsDisclaimerAccepted { get; set; }

    public string ConfirmationCode { get; set; }

    public DateTimeOffset? ConfirmationCodeCreated { get; set; }

    public int AuthenticationTryCount { get; set; }

    public DateTimeOffset? LastAuthenticationTry { get; set; }

    public bool IsIdentified { get; set; }

    public bool? IsAccessDenied { get; set; }

    public string PassHashWord { get; set; }
}
