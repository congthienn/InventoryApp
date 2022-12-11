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
        Task<BranchModelRq> GetBranchByCode(string code);
        Task<BranchModelRq> GetBranchById(Guid id);
        IEnumerable<BranchModelRq> GetAllBranches();
        Task<BranchModelRq> AddBranch(BranchModelRq model, UserIdentity userIdentity);
        Task<BranchModelRq> UpdateBranch(BranchUpdateModel model, UserIdentity userIdentity);
        Task<bool> DeleteBranch(Guid branchId);
        Task<bool> MainBranchAlreadyExists();
        IEnumerable<ShipmentModelRq> GetAllShipmentByBranch(Guid branchId);
        Task<bool> NameAlreadyExists(string name);
        Task<bool> EmailAlreadyExists(string email);
        Task<bool> PhoneAlreadyExists(string phone);
        Task<bool> FaxAlreadyExists(string fax);
        IEnumerable<BranchModelRq> GetAllBranchByUserId(Guid userId);
    }
}
