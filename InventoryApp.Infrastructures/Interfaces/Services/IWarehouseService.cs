using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IWarehouseService
    {
        IEnumerable<WarehouseModel> GetAllWarehouses();
        Task<WarehouseModel> GetWarehouseById(Guid id);
        Task<WarehouseModel> AddWarehouse(WarehouseModel model, UserIdentity userIdentity);
        Task<WarehouseModel> UpdateWarehouse(Guid id, WarehouseModel model, UserIdentity userIdentity);
        Task<bool> DeleteWarehouse(Guid id);
    }
}
