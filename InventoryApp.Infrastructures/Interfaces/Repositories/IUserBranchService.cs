using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IUserBranchService
    {
        Task<bool> UpdateBranchToUser(UserBranchModelRq model);
        Task<bool> DeleteBranchToUser(UserBranchModelRq model);
        IEnumerable<string> GetAllUsersOfTheBranch(Guid branchId);
        IEnumerable<string> GetAllBranchOfTheUser(Guid userId);
    }
}
