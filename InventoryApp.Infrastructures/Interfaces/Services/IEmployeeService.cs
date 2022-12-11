using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task AddEmployee(EmployeeModel model, UserIdentity userIdentity);
        IEnumerable<EmployeeModel> GetAllEmployee(); 
        IEnumerable<EmployeeModel> GetEmployeeByBranchId(Guid branchId);
        Task<EmployeeModel> GetEmployeeById(Guid employeeId);
        Task DeleteEmployee(Guid employeeId);
    }
}
