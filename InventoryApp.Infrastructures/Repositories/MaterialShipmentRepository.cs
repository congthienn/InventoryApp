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
    public class MaterialShipmentRepository : GenericRepository<MaterialShipment>, IMaterialShipmentRepository
    {
        public MaterialShipmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Materials> GetMaterialByShipmentId(Guid shipmentId)
        {
           return await _dbSet.Include(x=>x.Material).Where(x=>x.ShipmentId == shipmentId).Select(x=>x.Material).FirstOrDefaultAsync();
        }

        public async Task<int> GetMaterialQuantityByMaterialIdAndBranchId(Guid materialId, Guid branchId)
        {
            return await _dbSet.Where(x => x.Shipment.BranchId == branchId && x.MaterialId == materialId).SumAsync(x=>x.QuantityInStock);
        }

        public MaterialShipment GetMaterialShipmentByShipmentIdAndMaterialId(Guid shipmentId, Guid materialId)
        {
            return _dbSet.Where(x => x.ShipmentId == shipmentId && x.MaterialId == materialId).FirstOrDefault();
        }
    }
}
