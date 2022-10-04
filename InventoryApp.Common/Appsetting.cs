using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp.Common
{
    public static class Appsetting
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        public static string GetConnectionStringDatabase()
        {
            return GetConfiguration().GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public static string GetProvincialAPI()
        {
            return GetConfiguration().GetSection("ProvincesAPI").Value;
        }
    }
}