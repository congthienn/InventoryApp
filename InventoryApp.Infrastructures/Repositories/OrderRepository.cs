using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DbSet<OrderDetail> _dbSetOrderDetail;
        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbSetOrderDetail = _context.Set<OrderDetail>();
        }

        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            await _dbSetOrderDetail.AddAsync(orderDetail);
        }

        public async Task DeleteOrderDetail(OrderDetail orderDetail)
        {
            _dbSetOrderDetail.Remove(orderDetail);
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }

        public async Task<Order> GetOrderByCode(string code)
        {
            return await _dbSet.Include(x=>x.OrderDetail).FirstAsync(x => x.Code == code);
        }

        public IEnumerable<Order> GetOrderByStatus(int status)
        {
            return _dbSet.Where(x=>x.Status == status);
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _dbSetOrderDetail.FindAsync(id);
        }

        public async Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            _dbSetOrderDetail.Attach(orderDetail);
            _context.Entry(orderDetail).State = EntityState.Modified;
        }
    }
}
