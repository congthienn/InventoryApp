using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IShipmentRepository : IGenericRepository<Shipment>
    {
        IEnumerable<MaterialShipment> GetAllShipments();
        IEnumerable<Shipment> GetAllShipmentsByBranchId(Guid branchId);
        IEnumerable<MaterialShipment> GetAllShipmentHasProductByBranchId(Guid branchId);
        IEnumerable<MaterialShipment> GetAllShipmentByMaterialIdAndBranchId(Guid materialId, Guid branchId);
    }
}
