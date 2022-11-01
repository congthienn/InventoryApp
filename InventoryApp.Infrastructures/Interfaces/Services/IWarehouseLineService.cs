using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IWarehouseLineService
    {
        IEnumerable<WarehouseShelveModel> GetAllWarehouseShelve(Guid warehouseLineId);
        Task<WarehouseLineModel> GetWarehouseLineById(Guid id);
        Task<WarehouseLineModel> AddWarehouseLine(WarehouseLineModel model, UserIdentity userIdentity);
        Task<WarehouseLineModel> UpdateWarehouseLine(Guid id, WarehouseLineModel model, UserIdentity userIdentity);
        Task<bool> DeleteWarehouseLine(Guid id);
    }
}
