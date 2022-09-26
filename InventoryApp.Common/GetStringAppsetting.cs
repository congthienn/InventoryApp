﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp.Common
{
    public static class GetStringAppsetting
    {
        public static IConfigurationRoot GetAppSettings()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        public static string GetConnectionStringDatabase()
        {
            return GetAppSettings().GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}