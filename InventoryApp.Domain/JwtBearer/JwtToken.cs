﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.JwtBearer
{
    public class JwtToken
    {
        public string Access_token { set; get; }
        public string Token_type { set; get; }
        public double Expires_in { set; get; } // seconds

        public DateTimeOffset Expires_date { set; get; }
        public DateTimeOffset Issue_date { set; get; }
    }
}
