using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class CustomerGroupController : BaseController
    {
        private readonly ICustomerGroupService _customerGroupService;
        public CustomerGroupController(ICustomerGroupService customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }
        [HttpGet]
        public IEnumerable<CustomerGroupModel> GetAllCustomerGroups()
        {
            return _customerGroupService.GetAllCustomerGroups();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerGroupById(Guid id)
        {
            return Ok(await _customerGroupService.GetCustomerGroupById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerGroup([FromBody ]CustomerGroupModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _customerGroupService.AddCustomerGroup(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerGroup(Guid id, CustomerGroupModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _customerGroupService.UpdateCustomerGroup(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerGroup(Guid id)
        {
            try
            {
                return Ok(await _customerGroupService.DeleteCustomerGroup(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
