using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderModel> GetAllOrder();
        Task<OrderModel> GetOrderByCode(string code);
        IEnumerable<OrderModel> GetAllOrderByStatus(int status);
        IEnumerable<OrderModel> GetAllOrderByBranchId(Guid branchId);
        IEnumerable<OrderModel> GetOrderListByUserId(Guid userId);
        Task DeleteOrder(string code);
        IEnumerable<OrderModel> GetOrderListByBranchId(Guid branchId);
        Task<OrderModel> AddOrder(OrderModel model, UserIdentity userIdentity);
        Task<OrderModel> UpdateOrder(string code, OrderModel model, UserIdentity userIdentity);
        Task<OrderModel> UpdateStatusOrder(string code, UserIdentity userIdentity);
        Task<OrderModel> UpdateOrderPayment(string code, UserIdentity userIdentity);
        Task<bool> DeleteOrderDetail(int id);
        IEnumerable<MaterialModelRq> GetAllMaterialOrderByOrderId(int orderId);
        Task<int> GetQuantityRequest(int orderId, Guid materialId);
        Task AddReturnMaterial(ReturnedMaterialModel model, UserIdentity userIdentity);
    }
}
