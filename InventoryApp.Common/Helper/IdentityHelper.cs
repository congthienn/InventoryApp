using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryApp.Common.Helper
{
    public static class IdentityHelper
    {
        public static bool IsValidPassword(string password)
        {
            Regex passwordRules = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10,}$");
            return passwordRules.IsMatch(password);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            Regex phoneNumberRules = new Regex(@"^\d{10}$");
            return phoneNumberRules.IsMatch(phoneNumber);
        }
    }
}
