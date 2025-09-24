using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxGetUserDetailsByUserIdsRequest : ServiceBaseWebRequest
    {
        public long[] ListUserIds { get; set; }
    }

    public class ServiceMedimaxGetUserDetailsByUserIdsResponse : ServiceBaseWebResponse
    {
        public List<UserBasicInfoDto> ListUserDetails { get; set; }

        public class UserBasicInfoDto
        {
            public long UserId { get; set; }
            public byte RecordState { get; set; }
            public byte UserState { get; set; }
            public int? Speciality { get; set; }
            public int State { get; set; }
        }
    }
}
