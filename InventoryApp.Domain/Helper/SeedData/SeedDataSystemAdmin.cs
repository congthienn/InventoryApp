using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Data;
using InventoryApp.Infrastructures.Helper;
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
            await SeedDataUser(serviceProvider, dbContext);
                //await SeedDataRole(serviceProvider, dbContext);
        }
        private static async Task SeedDataUser(IServiceProvider serviceProvider, DbContext dbContext)
        {
            try
            {
                if (!dbContext.Set<Users>().AnyAsync().Result)
                {
                    var userManagement = serviceProvider.GetService<UserManager<Users>>();
                    Guid guid = Guid.NewGuid();
                    Users user = new Users
                    {
                        Id = guid,
                        UserName = "Systems",
                        Email = "system@gmail.com",
                        PhoneNumber = "0911440609",
                        Status = true,
                        EmailConfirmed = true,
                    };
                    UserIdentity userIdentity = new UserIdentity
                    {
                        Id = guid,
                        UserName = user.UserName
                    };
                    user.CreateBy(userIdentity);
                    user.UpdateBy(userIdentity);
                    await userManagement.CreateAsync(user, "SystemPassword@1");
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private static async Task SeedDataRole(IServiceProvider serviceProvider, DbContext dbContext)
        {
            List<string> listRole = new List<string>()
            {
                    ROLE_CONSTANT.SYSADMIN,
                    ROLE_CONSTANT.ADMIN,
                    ROLE_CONSTANT.DIRECTOR,
                    ROLE_CONSTANT.MANAGER,
                    ROLE_CONSTANT.EMPLOYEE,
                    ROLE_CONSTANT.SUPPLIER,
                    ROLE_CONSTANT.CUSTOMER,
            };
            try
            {
                if (!dbContext.Set<Roles>().AnyAsync().Result)
                {
                    var userManagement = serviceProvider.GetService<UserManager<Users>>();
                    var roleManagement = serviceProvider.GetService<RoleManager<Roles>>();
                    Users user = userManagement.FindByNameAsync("Systems").Result;
                    UserIdentity userIdentity = new UserIdentity
                    {
                        Id = user.Id,
                        UserName = user.UserName
                    };
                    foreach (var role in listRole)
                    {
                        Roles newRole = new Roles { Name = role };
                        newRole.CreateBy(userIdentity);
                        newRole.UpdateBy(userIdentity);
                        await roleManagement.CreateAsync(newRole);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
    }
}
