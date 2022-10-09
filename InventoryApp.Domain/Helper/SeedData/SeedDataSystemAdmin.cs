using InventoryApp.Data;
using InventoryApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace InventoryApp.Domain.Helper.SeedData
{
    public static class SeedDataSystemAdmin
    {
        private static readonly ILogger _log = LoggerHelper.GetConfig();
        public static async void Run(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<InventoryDBContext>();
            try
            {
                if (!TableUserIsEmpty(dbContext).Result)
                {
                    var userManagement = serviceProvider.GetService<UserManager<Users>>();
                    Guid guid = Guid.NewGuid();
                    var user = new Users
                    {
                        Id = guid,
                        UserName = "Systems",
                        Email = "system@gmail.com",
                        PhoneNumber = "0911440609",
                        Status = true
                    };
                    user.CreateBy(user);
                    user.UpdateBy(user);
                    await userManagement.CreateAsync(user, "SystemPassword@1");
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private static async Task<bool> TableUserIsEmpty(DbContext dbContext)
        {
            return await dbContext.Set<Users>().AnyAsync();
        }
    }
}
