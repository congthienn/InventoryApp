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
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Shipment> GetAllShipmentsByBranchId(Guid branchId)
        {
            return _dbSet.Where(x => x.BranchId == branchId).ToList().Where(x=> !ShipmentHasProducts(x.Id));
        }
        private bool ShipmentHasProducts(Guid shippmentId)
        {
            return _context.Set<MaterialShipment>().Any(x => x.ShipmentId == shippmentId);
        }
    }
}
