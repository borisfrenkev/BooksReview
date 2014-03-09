using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BookReviews.Helpers
{
    public class UrlHandler
    {
        public static string HandleUrl(string text)
        {
            if (text==null)
            {
                return string.Empty;
            }
            string result = text;
            Regex regx =
              new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?",
              RegexOptions.IgnoreCase);
            MatchCollection mactches = regx.Matches(result);
            foreach (Match match in mactches)
            {
                result = result.Replace(match.Value, "<a href='" + match.Value + "'>" + match.Value + "</a>");
            }

            return result;
        }
    }
}