using System.Collections.Generic;
using System;

public static class PhoneHelper
{
    public static readonly Dictionary<string, string> CountryDialingCodes = new Dictionary<string, string>
{
    { "MAL", "60" }, // Malaysia
    { "SGP", "65" }, // Singapore
    { "THA", "66" }, // Thailand
    { "IND", "91" }, // India
    { "CHN", "86" }, // China
    { "JPN", "81" }, // Japan
    { "KOR", "82" }, // South Korea
    { "PHL", "63" }, // Philippines
    { "VNM", "84" }, // Vietnam
    { "IDN", "62" }, // Indonesia
    { "LKA", "94" }, // Sri Lanka
    { "BGD", "880" }, // Bangladesh
    { "PAK", "92" }, // Pakistan
    { "MMR", "95" }, // Myanmar
    { "KHM", "855" }, // Cambodia
    { "LAO", "856" }, // Laos
    { "BRN", "673" }, // Brunei
    { "BTN", "975" }, // Bhutan
    { "MNG", "976" }, // Mongolia
    { "TLS", "670" }  // Timor-Leste
};

    public static string NormalizeForDb(string phone, string countryCode)
    {
        if (phone.StartsWith(countryCode))
            return "0" + phone.Substring(countryCode.Length);
        if (phone.StartsWith("0"))
            return phone;
        throw new ArgumentException("Invalid mobile number format.");
    }

    public static string NormalizeForSms(string phone, string countryCode)
    {
        if (phone.StartsWith("0"))
            return countryCode + phone.Substring(1);
        if (phone.StartsWith(countryCode))
            return phone;
        throw new ArgumentException("Invalid mobile number format.");
    }
}
