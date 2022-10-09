using InventoryApp.Data;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Helper.SeedData
{
    public static class SeedDataRole
    {
        private static readonly ILogger _log = LoggerHelper.GetConfig();
        private static List<string> listRole = new List<string>()
        {
            ROLE_CONSTANT.SYSADMIN,
            ROLE_CONSTANT.ADMIN,
            ROLE_CONSTANT.DIRECTOR,
            ROLE_CONSTANT.MANAGER,
            ROLE_CONSTANT.EMPLOYEE,
            ROLE_CONSTANT.SUPPLIER,
            ROLE_CONSTANT.CUSTOMER,
        };
        public static async void Run(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<InventoryDBContext>();
            try
            {
                if (!TableRoleIsEmpty(dbContext).Result)
                {
                    var userManagement = serviceProvider.GetService<UserManager<Users>>();
                    var roleManagement = serviceProvider.GetService<RoleManager<Roles>>();
                    Users users = userManagement.FindByNameAsync("Systems").Result;
                    foreach(var role in listRole)
                    {
                        Roles newRole = new Roles { Name = role };
                        newRole.CreateBy(users);
                        newRole.UpdateBy(users);
                        await roleManagement.CreateAsync(newRole);    
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private static async Task<bool> TableRoleIsEmpty(DbContext dbContext)
        {
            return await dbContext.Set<Roles>().AnyAsync();
        }
    }
}
