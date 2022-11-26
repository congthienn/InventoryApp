using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IWarehouseShelveRepository : IGenericRepository<WarehouseShelves>
    {
        Task<string> GetLastCode(Guid warehouseLineId);
        IEnumerable<WarehouseShelves> GetWarehouseShelveByWarehouseLineId(Guid warehouseLineId);
    }
}
