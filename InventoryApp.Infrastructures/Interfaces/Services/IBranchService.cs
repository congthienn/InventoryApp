using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IBranchService
    {
        Task<BranchModelRq> GetBranchById(Guid branchId);
        IEnumerable<BranchModelRq> GetAllBranches();
        Task<BranchModelRq> AddBranch(BranchModelRq model, UserIdentity userIdentity);
        Task<BranchModelRq> UpdateBranch(BranchUpdateModel model, UserIdentity userIdentity);
        Task<bool> DeleteBranch(Guid branchId);
        Task<bool> MainBranchAlreadyExists();
        IQueryable GetAllShipmentByBranch(Guid branchId);
    }
}
