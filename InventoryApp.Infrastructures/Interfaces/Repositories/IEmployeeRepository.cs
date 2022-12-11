using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<string> GetLastCode();
        IEnumerable<Employee> GetAllEmployee();
        Task<Employee> GetEmployeeById(Guid employeeId);
        IEnumerable<Employee> GetEmployeeByBranchId(Guid branchId);
    }
}
