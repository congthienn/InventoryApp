using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<string> GetLastCode();
        IEnumerable<Order> GetAllOrderByBranchId(Guid branchId);
        IEnumerable<Order> GetOrderListByBranchId(Guid branchId);
        IEnumerable<Materials> GetAllMaterialOrderByOrderId(int orderId);
        IEnumerable<Order> GetAllOrders();
        Task<Order> GetOrderByCode(string code);
        IEnumerable<Order> GetOrderByStatus(int status);
        Task AddOrderDetail(OrderDetail orderDetail);
        Task DeleteOrderDetail(OrderDetail orderDetail);
        Task UpdateOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> GetOrderDetailById(int id);
        Task<int> GetQuantityRequest(int orderId, Guid materialId);
    }
}
