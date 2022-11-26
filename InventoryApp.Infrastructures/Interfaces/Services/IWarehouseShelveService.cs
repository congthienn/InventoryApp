using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IWarehouseShelveService
    {
        Task<WarehouseShelveModel> GetWarehouseShelveById(Guid id);
        IEnumerable<WarehouseShelveModel> GetWarehouseShelveNoHasProductByWarehouseLineId(Guid warehouseLineId);
        IEnumerable<WarehouseShelveModel> GetWarehouseShelveByWarehouseLineId(Guid warehouseLineId);
        
        Task<WarehouseShelveModel> AddWarehouseShelve(WarehouseShelveModel model, UserIdentity userIdentity);
        Task<WarehouseShelveModel> UpdateWarehouseShelve(Guid id, WarehouseShelveModel model, UserIdentity userIdentity);
        Task<bool> DeleteWarehouseShelve(Guid id);
    }
}
    