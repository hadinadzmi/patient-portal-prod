namespace PatientPortalBackend.Models
{
    public class ServiceBaseWebResponse
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
