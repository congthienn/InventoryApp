using InventoryApp.Common;
using Serilog;
using Serilog.Core;
using Serilog.Filters;

namespace InventoryApp.Domain.Helper
{
    public static class LoggerHelper
    {
        public static ILogger GetConfig()
        {
            return new LoggerConfiguration()
              .ReadFrom.Configuration(Appsetting.GetConfiguration())
              .Filter.ByExcluding(Matching.FromSource("Microsoft"))
              .Filter.ByExcluding(Matching.FromSource("System")).Enrich.FromLogContext().CreateLogger();
        }
    }
}
