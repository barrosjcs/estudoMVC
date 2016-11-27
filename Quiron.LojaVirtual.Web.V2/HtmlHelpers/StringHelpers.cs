using System.Text.RegularExpressions;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    public static class StringHelpers
    {
        public static string ToSeoUrl(this string url)
        {
            // Make url lowercase
            string encodeUrl = (url ?? "").ToLower();

            // replace & with and
            encodeUrl = Regex.Replace(encodeUrl, @"\&+", "and");

            // remove characters
            encodeUrl = encodeUrl.Replace("'", "");

            encodeUrl = Regex.Replace(encodeUrl, @"[^a-z0-9]", "-");

            // remove duplicates
            encodeUrl = Regex.Replace(encodeUrl, @"-+", "-");

            // trim leading & trailing characters
            encodeUrl = encodeUrl.Trim('-');

            return encodeUrl;
        }
    }
}