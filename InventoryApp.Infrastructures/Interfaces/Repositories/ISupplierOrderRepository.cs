using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface ISupplierOrderRepository : IGenericRepository<SupplierOrder>
    {
        Task<string> GetLastCode();
        IEnumerable<SupplierOrder> GetAllSupplierOrder();
        IEnumerable<Materials> GetAllMaterialOrderByOrderId(int orderId);
        IEnumerable<SupplierOrder> GetAllSupplierOrderByBranchId(Guid branchId);
        Task<SupplierOrder> GetSupplierOrderByCode(string code);
        IEnumerable<SupplierOrder> GetSupplierOrderByStatus(int status);
        Task DeleteSupplierOrderDetail(SupplierOrderDetail supplierOrderDetail);
        Task<SupplierOrderDetail> GetSupplierOrderDetailById(int id);
        Task<int> GetQuantityRequest(int orderId, Guid materialId);
    }
}
