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
    public class WarehouseRepository : GenericRepository<Warehouses>, IWarehouseRepository
    {
        public WarehouseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<WarehouseArea> GetAllWarehouseAreas(Guid warehouseId)
        {
            return _dbSet.Where(x=>x.Id == warehouseId).Select(x=>x.WarehouseAreas).FirstOrDefault();
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}
