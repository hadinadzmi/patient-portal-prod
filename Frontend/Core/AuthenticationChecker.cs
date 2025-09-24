using Blazored.LocalStorage;

namespace Patient_Portal.Core
{
    public class AuthData
    {
        public Guid PatientID { get; set; }
        public string PatientNRIC { get; set; }
        public string PatientName { get; set; }
        public string PatientMobileNumber { get; set; }
        public string PatientDOB { get; set; }
        public DateTime Date { get; set; }

        public AuthData() { }

        public AuthData(DateTime date,Guid patId, string patNric, string patName, string patientMobileNumber, string patientDOB)
        {
            Date = date;
            PatientID = patId;
            PatientNRIC = patNric;
            PatientName = patName;
            PatientMobileNumber = patientMobileNumber;
            PatientDOB = patientDOB;
        }
    }
    public static class AuthenticationChecker
    {
        public static async Task<bool> IsAuthenticated(ILocalStorageService localStorage)
        {
            var cookie = await localStorage.GetItemAsync<AuthData>(GlobalData.KEY_AUTH);
            Console.WriteLine($"Auth check: {cookie?.PatientNRIC} == {GlobalData.PatientNRIC} && {DateTime.Now.AddHours(-3)} <= {cookie?.Date}");
            if (cookie != null && cookie.PatientNRIC == GlobalData.PatientNRIC && DateTime.Now.AddHours(-3) <= cookie.Date)
                return true;
            return false;
        }
    }
}
