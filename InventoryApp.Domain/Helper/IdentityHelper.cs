﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Helper
{
    public static class IdentityHelper
    {
        public static bool IsValidPassword(string password)
        {
            Regex passwordRules = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10,}$");
            return passwordRules.IsMatch(password);
        }
    }
}
