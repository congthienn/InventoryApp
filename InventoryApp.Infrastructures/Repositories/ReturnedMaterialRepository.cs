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
    public class ReturnedMaterialRepository : GenericRepository<ReturnedMaterial>, IReturnedMaterialRepository
    {
        public ReturnedMaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ReturnedMaterial> GetReturnedMaterialByOrderId(int orderId)
        {
            return await _dbSet.Include(x => x.Detail).Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
        }
    }
}
