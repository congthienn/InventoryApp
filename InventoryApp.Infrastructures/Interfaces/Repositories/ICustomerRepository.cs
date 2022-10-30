using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<string> GetLastCode();
    }
}
