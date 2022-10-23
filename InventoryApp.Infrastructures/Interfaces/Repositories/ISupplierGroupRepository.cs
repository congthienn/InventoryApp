using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface ISupplierGroupRepository : IGenericRepository<SupplierGroup>
    {
        IQueryable GetAllSupplierByGroupId(Guid groupSupplierId);
    }
}