using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IMaterialShipmentRepository : IGenericRepository<MaterialShipment>
    {
        Task<Materials> GetMaterialByShipmentId(Guid shipmentId);
        MaterialShipment GetMaterialShipmentByShipmentIdAndMaterialId(Guid shipmentId, Guid materialId);
    }
}
