using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryApp.Common.Helper
{
    public static class StringHelper
    {  
        public static string RemoveExtraWhitespace(this string text)
        {
            Regex trimmer = new Regex(@"\s\s+");
            return trimmer.Replace(text, " ");
        }

        public static string NormalizeString(string text)
        {
            return text.Trim().ToLower().RemoveExtraWhitespace().Replace(" ", "-");
        }
    }
}
