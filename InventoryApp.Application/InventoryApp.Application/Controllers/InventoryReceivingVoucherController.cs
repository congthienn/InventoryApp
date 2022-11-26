using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class InventoryReceivingVoucherController : BaseController
    {
        private readonly IInventoryReceivingVoucherService _inventoryReceivingVoucherService;
        public InventoryReceivingVoucherController(IInventoryReceivingVoucherService inventoryReceivingVoucherService)
        {
            _inventoryReceivingVoucherService = inventoryReceivingVoucherService;
        }

        [HttpGet("GetInventoryReceivingVoucher")]
        public IEnumerable<InventoryReceivingVoucherModel> GetInventoryReceivingVoucher()
        {
            return _inventoryReceivingVoucherService.GetInventoryReceivingVoucher();
        }

        [HttpPost]
        public async Task<IActionResult> AddInventoryReceivingVoucher([FromBody] InventoryReceivingVoucherModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _inventoryReceivingVoucherService.AddInventoryReceivingVoucher(model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
