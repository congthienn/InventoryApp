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
    public class WarehouseLineRepository : GenericRepository<WarehouseLine>, IWarehouseLineRepository
    {
        public WarehouseLineRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<WarehouseLine> GetAllWarehouseLine(Guid warehouseAreaId)
        {
            return _dbSet.Where(x => x.WarehouseAreaId == warehouseAreaId).OrderByDescending(x=>x.CreatedDate);
        }

        public IEnumerable<WarehouseShelves> GetAllWarehouseShelve(Guid warehouseLineId)
        {
            return _dbSet.Where(x => x.Id == warehouseLineId).Select(x => x.WarehouseShelves).FirstOrDefault();
        }

        public async Task<string> GetLastCode(Guid warehouseAreaId)
        {
            return _dbSet.Where(x => x.WarehouseAreaId == warehouseAreaId).OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}