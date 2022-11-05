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
        Task<OrderModel> AddOrder(OrderModel model, UserIdentity userIdentity);
        Task<OrderModel> UpdateOrder(string code, OrderModel model, UserIdentity userIdentity);
        Task<OrderModel> UpdateStatusOrder(string code, OrderStatusModel status, UserIdentity userIdentity);
        Task<bool> DeleteOrderDetail(int id);
    }
}
