using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IBranchRepository : IGenericRepository<Branches>
    {
        Task<string> GetLastCode();
        Task<bool> MainBranchAlreadyExists();
        Task<Branches> GetBranchByCode(string code);
        IEnumerable<Shipment> GetAllShipmentByBranch(Guid branchId);
    }
}
