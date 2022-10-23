using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class SupplierGroupController : BaseController
    {
        private readonly ISupplierGroupService _supplierGroupService;
        public SupplierGroupController(ISupplierGroupService supplierGroupService) {
            _supplierGroupService = supplierGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplierGroup([FromBody] SupplierGroupModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _supplierGroupService.AddSupplierGroup(model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IEnumerable<SupplierGroupModelRq> GetAllSupplierGroup()
        {
            return _supplierGroupService.GetAllSupplierGroup();
        }

        [HttpPut("{supplierGroupId}")]
        public async Task<IActionResult> UpdateSupplierGroup(Guid supplierGroupId, [FromBody]SupplierGroupModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _supplierGroupService.UpdateSupplierGroup(supplierGroupId, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{supplierGroupId}")]
        public async Task<IActionResult> DeleteSupplierGroup(Guid supplierGroupId)
        {
            try
            {
                return Ok(await _supplierGroupService.DeleteSupplierGroup(supplierGroupId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
