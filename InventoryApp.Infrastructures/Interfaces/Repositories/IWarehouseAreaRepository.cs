using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IWarehouseAreaRepository : IGenericRepository<WarehouseArea>
    {
        Task<string> GetLastCode(Guid warehouseId);
        IEnumerable<WarehouseArea> GetAllWarehouseAreaByWarehouseId(Guid warehouseId);
        IEnumerable<WarehouseLine> GetAllWarehouseLine(Guid warehouseAreaId);
    }
}
