using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceGetUsersDetailsByUserIdRequest : ServiceBaseWebRequest
    {
        //public List<long> UserIds { get; set; }
        //public long CustomerId { get; set; } 
        //public long TenantId { get; set; }
        public long[] UserIds { get; set; } // Ensure this is an array
        public long CustomerId { get; set; }
        public long TenantId { get; set; }
    }
    public class ServiceGetUsersDetailsByUserIdResponse : ServiceBaseWebResponse
    {
        public List<UserDetailsDto> UserDetails { get; set; }

        public class UserDetailsDto
        {
            public long UserId { get; set; }
            public string UserLastName { get; set; }
            public string UserFirstName { get; set; }
        }
    }
}
