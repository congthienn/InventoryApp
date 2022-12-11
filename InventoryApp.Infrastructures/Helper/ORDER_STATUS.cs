﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Helper
{
    public enum ORDER_STATUS
    {
        Processing,
        Approved,
        Export,
        Delivering,
        Done,
        Returned,
        Cancel
    }
}
