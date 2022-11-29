using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task AddEmployee([FromForm] EmployeeModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                await _employeeService.AddEmployee(model, userIdentity);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }

        [Route("GetAllEmployee")]
        [HttpGet]
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _employeeService.GetAllEmployee();
        }

        [Route("GetEmployeeById/{employeeId}")]

        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            return Ok(await _employeeService.GetEmployeeById(employeeId));
        }

        [Route("DeleteEmployeeById/{employeeId}")]
        [HttpDelete]
        public async Task DeleteEmployee(Guid employeeId)
        {
            try
            {
                await _employeeService.DeleteEmployee(employeeId);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
            }
        }
    }
}
