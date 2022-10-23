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
        
        public static string CreateCode(string code)
        {
            Regex regex = new Regex(@"[\d]");
            int numberCode = Convert.ToInt32(code.Replace(regex.Replace(code, ""), ""));
            numberCode++;
            int numberLength = numberCode.ToString().Length;
            int removeLength = code.Length - numberLength;
            return code.Remove(removeLength, numberLength) + numberCode.ToString();
        }
    }
}
