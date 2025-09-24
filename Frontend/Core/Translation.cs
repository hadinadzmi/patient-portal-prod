using Microsoft.Extensions.Localization;
using Patient_Portal.Shared.ResourceFiles;

namespace Patient_Portal.Core
{
    public static class Trans
    {
        public static string GetStr(IStringLocalizer<Resource> localizer, string key, string defVal = null)
        {
            return Translation.GetString(localizer, key, defVal);
        }
    }
    public static class Translation
    {
        public static string GetString(IStringLocalizer<Resource> localizer, string key, string defVal = null)
        {
            var transl = localizer[key];
            if (transl != key)
                return transl;

                //if (TestGlobals.TranslationTest)
                //    return key;

                return defVal ?? key;
        }
    }
}
