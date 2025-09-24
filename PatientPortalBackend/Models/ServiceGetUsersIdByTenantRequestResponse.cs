using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceGetUsersIdByTenantRequest : ServiceBaseWebRequest
    {
        public long CustomerId { get; set; }
        public long TenantId { get; set; }
    }

    public class ServiceGetUsersIdByTenantResponse : ServiceBaseWebResponse
    {
        public List<UserIdListDto> UserList { get; set; }
    }

    public class UserIdListDto
    {
        public long UserId { get; set; }
        public byte RecordState { get; set; }
    }

}
