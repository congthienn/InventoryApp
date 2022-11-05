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

        public async Task<InventoryDeliveryVoucher> GetInventoryDeliveryVoucherByCode(string code)
        {
            return await _dbSet.Include(x => x.Details).Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public IEnumerable<InventoryDeliveryVoucher> GetInventoryDeliveryVoucherByCodeByPurpose(int purpose)
        {
            return _dbSet.Include(x => x.Details).Where(x => x.Purpose == purpose);
        }

        public IEnumerable<InventoryDeliveryVoucher> GetInventoryDeliveryVoucherByCodeByStatus(int status)
        {
            return _dbSet.Include(x => x.Details).Where(x => x.Status == status);
        }

        public async Task<string> GetLastCode()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefaultAsync();
        }
    }
}
