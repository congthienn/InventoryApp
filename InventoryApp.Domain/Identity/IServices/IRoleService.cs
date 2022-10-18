using InventoryApp.Data.Helper;
using InventoryApp.Domain.Identity.DTO.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.IServices
{
    public interface IRoleService
    {
        IEnumerable<RoleModelRq> GetRoleList();
        Task<RoleModelRq> GetRoleById(Guid id);
        Task<RoleModelRq> AddRoleAsync(RoleModelRq model, UserIdentity issuer);
        Task<RoleModelRq> UpdateRoleAsync(Guid id, RoleModelRq model, UserIdentity issuer);
        Task<bool> DeleteRoleAsync(Guid id);
        IQueryable GetListUserRole(Guid userId);
        Task<RoleModelRq> GetRoleByName(string name);
    }
}