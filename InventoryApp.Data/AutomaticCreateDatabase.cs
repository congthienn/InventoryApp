using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryApp.Data
{
    public static class AutomaticCreateDatabase
    {
        public static async void Run(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<InventoryDBContext>();
                context.Database.Migrate();
            }
        }
    }
}