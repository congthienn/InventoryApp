using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Identity.DTO.Roles;
using InventoryApp.Domain.Identity.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.IServices
{
    public interface IUserService
    {
        IEnumerable<UserModelRq> GetUserList();
        IEnumerable<UserModelRq> GetUserLisByBranchId(Guid branchId);

        Task<UserModelRq> AddUserAsync(UserModelRq model, UserIdentity issuer);
        Task<UserModelRq> UpdateUserAsync(Guid id, UserUpdateRq model, UserIdentity issuer);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserModelRq> GetUserById(Guid id);
        Task<bool> UpdateRoleToUserAsync(UserRoleModelRq model);
        Task<bool> RemoveRoleToUserAsync(UserRoleModelRq model);
        IEnumerable<RoleModelRq> GetRoleByUser(Guid userId);
        Task<bool> CheckEmailAsync(string email);
        Task<bool> ActivateUserAccount(ConfirmEmailModelRq model);
        Task<bool> UpdateAccountStatus(UpdateAccountStatusModelRq model);
        Task<Employee> GetEmployeeByUserId(Guid userId);
    }
}
