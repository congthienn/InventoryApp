using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        IEnumerable<Supplier> GetAllSupplier();
        Task<string> GetLastCode();
    }
}
