using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface ISupplierOrderService
    {
        IEnumerable<SupplierOrderModel> GetAllSupplierOrder();
        Task<SupplierOrderModel> GetSupplierOrderByCode(string code);
        IEnumerable<SupplierOrderModel> GetAllSupplierOrderByStatus(int status);
        Task<SupplierOrderModel> AddSupplierOrder(SupplierOrderModel model, UserIdentity userIdentity);
        Task<SupplierOrderModel> UpdateSupplierOrder(string code, SupplierOrderModel model, UserIdentity userIdentity);
        Task<SupplierOrderModel> UpdateStatusSupplierOrder(string code,  UserIdentity userIdentity);
        Task<bool> DeleteSupplierOrderDetail(int id);
    }
}
