using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        IEnumerable<Roles> GetRoleByUser(Guid userId);
        IEnumerable<Branches> GetBranchByUser(Guid userId);
        IEnumerable<Users> GetUserListByBranchId(Guid branchId);
        Task<Employee> GetEmployeeByUserId(Guid userId);
    }
}
