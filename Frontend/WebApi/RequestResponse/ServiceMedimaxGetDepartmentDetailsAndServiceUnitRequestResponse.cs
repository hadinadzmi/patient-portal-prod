using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxGetDepartmentDetailsAndServiceUnitRequest : ServiceBaseWebRequest
    {
        public long? DepartmentId { get; set; }
        public long? ServiceUnitId { get; set; }
        public long? TenantId { get; set; }
    }

    public class DepartmentWithServiceUnitsDto
    {
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long TenantId { get; set; }
        public List<ServiceUnitDto> ServiceUnits { get; set; }
    }

    public class ServiceUnitDto
    {
        public long ServiceUnitId { get; set; }
        public string ServiceUnitName { get; set; }
        public long DepartmentId { get; set; }
        public long TenantId { get; set; }
    }

    public class ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse : ServiceBaseWebResponse
    {
        public List<DepartmentWithServiceUnitsDto> Departments { get; set; }
    }
}