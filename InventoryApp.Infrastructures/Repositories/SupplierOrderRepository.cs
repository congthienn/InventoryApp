using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Infrastructures.Repositories
{
    public class SupplierOrderRepository : GenericRepository<SupplierOrder>, ISupplierOrderRepository
    {
        private readonly DbSet<SupplierOrderDetail> _dbSetSupplierOrder;
        public SupplierOrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbSetSupplierOrder = _context.Set<SupplierOrderDetail>();
        }

        public async Task DeleteSupplierOrderDetail(SupplierOrderDetail supplierOrderDetail)
        {
            _dbSetSupplierOrder.Remove(supplierOrderDetail);
        }

        public IEnumerable<SupplierOrder> GetAllSupplierOrder()
        {
            return _dbSet.Include(x => x.BranchRequest).Include(x => x.Supplier).OrderByDescending(x => x.CreatedDate);
        }

        public IEnumerable<SupplierOrder> GetAllSupplierOrderByBranchId(Guid branchId)
        {
            return _dbSet.Where(x=>x.BranchRequestId == branchId && x.Status == 2).OrderByDescending(x => x.CreatedDate);
        }

        public async Task<string> GetLastCode()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefaultAsync();
        }

        public async Task<SupplierOrder> GetSupplierOrderByCode(string code)
        {
            return await _dbSet.Include(x => x.BranchRequest).Include(x => x.Supplier).Include(x=>x.SupplierOrderDetail).ThenInclude(x=>x.Material).Where(x=>x.Code == code).FirstOrDefaultAsync();
        }

        public IEnumerable<SupplierOrder> GetSupplierOrderByStatus(int status)
        {
            return _dbSet.Include(x => x.SupplierOrderDetail).Where(x => x.Status == status);
        }

        public async Task<SupplierOrderDetail> GetSupplierOrderDetailById(int id)
        {
            return await _dbSetSupplierOrder.FirstAsync(x => x.Id == id);
        }
    }
}