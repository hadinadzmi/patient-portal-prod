using System;
using System.Linq;
using PatientPortalBackend.DbModels;
using PatientPortalBackend.Models;
using PatientPortalBackend.Utils;

namespace PatientPortalBackend.Access
{
    public class AccessChecker
    {
        public static bool IsAccessDenied<T>(Guid patientId, out T errormsg) where T : ServiceBaseWebResponse
        {
            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                if (patientId != Guid.Empty)
                {
                    var confCodeEntry = context.PatientExtension.FirstOrDefault(p => p.PatientId == patientId);

                    if (confCodeEntry == null)
                    {
                        errormsg = BasicServiceWebHelper.CreateFaultResponse<T>("B300",
                            String.Format("Access to data of patient '{0}' is denied!", patientId));
                        return true;
                    }

                    if (confCodeEntry.IsAccessDenied == true)
                    {
                        errormsg = BasicServiceWebHelper.CreateFaultResponse<T>("B301",
                            String.Format("Access to data of patient '{0}' is denied!", patientId));
                        return true;
                    }
                }
                //TODO validation regarding vaild datetime ?
            }
            errormsg = BasicServiceWebHelper.CreateSuccessResponse<T>();
            return false;
        }

        public static bool IsAccessDenied<T>(PatientExtension extension, out T errormsg) where T : ServiceBaseWebResponse
        {
            if (extension.IsAccessDenied == true)
            {
                errormsg = BasicServiceWebHelper.CreateFaultResponse<T>("B301",
                    String.Format("Access to data of patient '{0}' is denied!", extension.PatientId));
                return true;
            }
            errormsg = BasicServiceWebHelper.CreateSuccessResponse<T>();
            return false;
        }

    }
}
