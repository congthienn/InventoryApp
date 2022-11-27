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
    public class MaterialPositionRepository : GenericRepository<MaterialPosition>, IMaterialPositionRepository
    {
        public MaterialPositionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<MaterialPosition> GetMaterialPositionsByBranchId(Guid branchId)
        {
            return _dbSet.Include(x => x.Material).Include(x => x.WarehouseShelve)
                            .ThenInclude(x => x.WarehouseLine)
                            .ThenInclude(x => x.WarehouseArea)
                            .ThenInclude(x => x.Warehouse)
                            .Include(x => x.Shipment).ThenInclude(x => x.Branch)
                            .Where(x => x.Shipment.BranchId == branchId);
        }
    }
}
