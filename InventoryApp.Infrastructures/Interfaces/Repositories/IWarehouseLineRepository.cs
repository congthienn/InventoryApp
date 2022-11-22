using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IWarehouseLineRepository : IGenericRepository<WarehouseLine>
    {
        Task<string> GetLastCode(Guid warehouseAreaId);
        IEnumerable<WarehouseShelves> GetAllWarehouseShelve(Guid warehouseLineId);
        IEnumerable<WarehouseLine> GetAllWarehouseLine(Guid warehouseAreaId);
    }
}
