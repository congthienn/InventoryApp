using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _dbSet.Include(x => x.Branch).Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).OrderByDescending(x=>x.CreatedDate);
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId)
        {
            return await _dbSet.Include(x => x.Branch).Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).FirstOrDefaultAsync();
        }

        public async Task<string> GetLastCode()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefaultAsync();
        }
    }
}
