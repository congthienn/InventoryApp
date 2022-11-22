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

        public IEnumerable<WarehouseArea> GetAllWarehouseAreaByWarehouseId(Guid warehouseId)
        {
            return _dbSet.Where(x => x.WarehouseId == warehouseId).OrderByDescending(x=>x.CreatedDate);
        }

        public IEnumerable<WarehouseLine> GetAllWarehouseLine(Guid warehouseAreaId)
        {
            return _dbSet.Where(x => x.Id == warehouseAreaId).Select(x => x.WarehouseLines).FirstOrDefault();
        }

        public async Task<string> GetLastCode(Guid warehouseId)
        {
            return _dbSet.Where(x=>x.WarehouseId == warehouseId).OrderByDescending(x=>x.CreatedDate).Select(x=>x.Code).FirstOrDefault();
        }
    }
}
