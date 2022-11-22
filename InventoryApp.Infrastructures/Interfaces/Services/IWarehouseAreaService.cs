using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IWarehouseAreaService
    {
        IEnumerable<WarehouseLineModel> GetWarehouseLine(Guid id);
        Task<WarehouseAreaModel> GetWarehouseAreaById(Guid id);
        IEnumerable<WarehouseAreaModel> GetAllWarehouseAreaByWarehouseId(Guid warehouseId);
        Task<WarehouseAreaModel> AddWarehouseArea(WarehouseAreaModel model, UserIdentity userIdentity);
        Task<WarehouseAreaModel> UpdateWarehouseArea(Guid id, WarehouseAreaModel model, UserIdentity userIdentity);
        Task<bool> DeleteWarehouseArea(Guid id);
    }
}
