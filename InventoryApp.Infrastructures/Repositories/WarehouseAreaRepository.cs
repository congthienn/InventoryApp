using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class WarehouseAreaRepository : GenericRepository<WarehouseArea>, IWarehouseAreaRepository
    {
        public WarehouseAreaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string> GetLastCode(Guid warehouseId)
        {
            return _dbSet.Where(x=>x.WarehouseId == warehouseId).OrderByDescending(x=>x.CreatedDate).Select(x=>x.Code).FirstOrDefault();
        }
    }
}
