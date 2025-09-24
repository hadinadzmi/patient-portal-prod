using System;
using System.Collections.Generic;

namespace PatientPortalBackend.DbModels;

public partial class ServerConfig
{
    public long PkId { get; set; }

    public long CustomerId { get; set; }

    public long TenantId { get; set; }

    public byte RecordState { get; set; }

    public byte[] RowVersion { get; set; }

    public string Key { get; set; }

    public byte[] ByteValue { get; set; }

    public string StringValue { get; set; }
}
