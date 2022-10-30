using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;

namespace InventoryApp.Infrastructures.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}
