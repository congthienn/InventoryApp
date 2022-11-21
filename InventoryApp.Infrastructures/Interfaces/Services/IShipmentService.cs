using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IShipmentService
    {
        Task<ShipmentModelRq> AddShipment(ShipmentModelRq model, UserIdentity userIdentity);
        Task<ShipmentModelRq> UpdateShipment(string shipmentId, ShipmentModelRq model, UserIdentity userIdentity);
        IEnumerable<ShipmentModelRq> GetAllShipments();
        IEnumerable<ShipmentModelRq> GetAllShipmentsByBranchId(Guid branchId);
        Task<bool> DeleteShipment(string shipmentId);
    }
}
