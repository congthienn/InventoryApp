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

        public IEnumerable<Warehouses> GetAllWarehouse()
        {
            return _dbSet.Include(x => x.Branch).OrderByDescending(x => x.CreatedDate);
        }

        public IEnumerable<WarehouseArea> GetAllWarehouseAreas(Guid warehouseId)
        {
            return _dbSet.Where(x=>x.Id == warehouseId).Select(x=>x.WarehouseAreas).FirstOrDefault();
        }

        public IEnumerable<Warehouses> GetAllWarehouseByBranchId(Guid branchId)
        {
            return _dbSet.Include(x => x.Branch).OrderByDescending(x => x.CreatedDate).Where(x=>x.BranchId == branchId);
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}
