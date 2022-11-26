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
    public class WarehouseShelveRepository : GenericRepository<WarehouseShelves>, IWarehouseShelveRepository
    {
        public WarehouseShelveRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string> GetLastCode(Guid warehouseLineId)
        {
            return _dbSet.Where(x => x.WarehouseLineId == warehouseLineId).OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }

        public IEnumerable<WarehouseShelves> GetWarehouseShelveByWarehouseLineId(Guid warehouseLineId)
        {
            return _dbSet.Where(x => x.WarehouseLineId == warehouseLineId).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public IEnumerable<WarehouseShelves> GetWarehouseShelveNoHasProductByWarehouseLineId(Guid warehouseLineId)
        {
            return _dbSet.Where(x => x.WarehouseLineId == warehouseLineId).OrderByDescending(x => x.CreatedDate).ToList().Where(x=> !WarehouseShelvevHasProducts(x.Id));
        }
        private bool WarehouseShelvevHasProducts(Guid warehouseShelveId)
            {
            return _context.Set<MaterialPosition>().Any(x => x.WarehouseShelveId == warehouseShelveId);
        }
    }
}
