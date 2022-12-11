using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IDeliveryCompanyRepository : IGenericRepository<DeliveryCompany>
    {
        IEnumerable<DeliveryCompany> GetAllDeliveryCompanyByBranchId(Guid branchId);
        Task<string> GetLastCode();
    }
}
