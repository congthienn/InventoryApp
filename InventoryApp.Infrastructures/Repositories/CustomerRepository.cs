using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Infrastructures.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _dbSet.Include(x => x.Branch).Include(x => x.CustomerGroup).Include(x=>x.Province).Include(x => x.District).Include(x => x.Ward).OrderByDescending(x=>x.UpdatedDate);
        }

        public IEnumerable<Customer> GetAllCustomerByBranchId(Guid branchId)
        {
            return _dbSet.Include(x => x.Branch).Include(x => x.CustomerGroup).Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).Where(x=>x.BranchId == branchId).OrderByDescending(x => x.UpdatedDate);
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}
