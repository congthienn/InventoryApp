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
        IEnumerable<Branches> GetAllBranch();
        Task<string> GetLastCode();
        Task<bool> MainBranchAlreadyExists();
        Task<Branches> GetBranchByCode(string code);
        IEnumerable<Shipment> GetAllShipmentByBranch(Guid branchId);
        Task<bool> NameAlreadyExists(string name);
        Task<bool> EmailAlreadyExists(string email);
        Task<bool> PhoneAlreadyExists(string phone);
        Task<bool> FaxAlreadyExists(string fax);

    }
}
