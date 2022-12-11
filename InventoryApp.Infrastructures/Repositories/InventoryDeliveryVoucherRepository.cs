using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Infrastructures.Repositories
{
    public class InventoryDeliveryVoucherRepository : GenericRepository<InventoryDeliveryVoucher>, IInventoryDeliveryVoucherRepository
    {
        public InventoryDeliveryVoucherRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<InventoryDeliveryVoucher> GetInventoryDeliveryVoucher()
        {
            return _dbSet.Include(x => x.Branch).Include(x => x.Warehouse).Include(x => x.Order).ThenInclude(x => x.Customer).OrderByDescending(x=>x.CreatedDate);
        }

        public async Task<InventoryDeliveryVoucher> GetInventoryDeliveryVoucherById(Guid inventoryDeliveryVoucherId)
        {
            return _dbSet.Include(x=>x.Details).ThenInclude(x=>x.Shipment)
                    .Include(x => x.Details).ThenInclude(x => x.Material)
                    .Include(x => x.Branch)
                    .Include(x => x.Warehouse)
                    .Include(x => x.Order).ThenInclude(x => x.Customer)
                    .Include(x=>x.UserDelivery)
                    .Where(x=>x.Id == inventoryDeliveryVoucherId).FirstOrDefault();
        }


        public async Task<string> GetLastCode()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefaultAsync();
        }
    }
}
