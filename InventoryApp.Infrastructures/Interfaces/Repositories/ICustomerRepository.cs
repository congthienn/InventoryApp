using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomer();
        IEnumerable<Customer> GetAllCustomerByBranchId(Guid branchId);
        Task<string> GetLastCode();
    }
}
