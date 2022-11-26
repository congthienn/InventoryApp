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
    public class InventoryReceivingVoucherRepository : GenericRepository<InventoryReceivingVoucher>, IInventoryReceivingVoucherRepository
    {
        public InventoryReceivingVoucherRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<InventoryReceivingVoucher> GetInventoryReceivingVoucher()
        {
            return _dbSet.Include(x => x.BranchRequest).Include(x => x.Warehouse).Include(x => x.SupplierOrder).ThenInclude(x=>x.Supplier);
        }

        public IEnumerable<InventoryReceivingVoucher> GetInventoryReceivingVoucherByBranchId(Guid branchId)
        {
            return _dbSet.Include(x=>x.Detail).Where(x=>x.BranchRequestId == branchId).OrderByDescending(x=>x.CreatedDate);
        }

        public async Task<InventoryReceivingVoucher> GetInventoryReceivingVoucherById(Guid inventoryReceivingVoucherId)
        {
            return await _dbSet.Include(x => x.Detail).ThenInclude(x => x.Shipment)
                    .Include(x=>x.BranchRequest).Include(x=>x.SupplierOrder).Include(x=>x.UserReceive)
                    .Include(x=>x.Warehouse).Where(x => x.Id == inventoryReceivingVoucherId).FirstOrDefaultAsync();
        }

        public async Task<string> GetLastCode()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefaultAsync();
        }
    }
}
