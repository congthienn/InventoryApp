using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class InventoryDeliveryVoucherController : BaseController
    {
        private readonly IInventoryDeliveryVoucherService _inventoryDeliveryVoucherService;
        public InventoryDeliveryVoucherController(IInventoryDeliveryVoucherService inventoryDeliveryVoucherService)
        {
            _inventoryDeliveryVoucherService = inventoryDeliveryVoucherService;
        }

        [HttpGet]
        public IEnumerable<InventoryDeliveryVoucherModel> GetAllInventoryDeliveryVoucher()
        {
            return _inventoryDeliveryVoucherService.GetAllInventoryDeliveryVoucher();
        }

        [HttpPost]
        public async Task<IActionResult> AddInventoryDeliveryVoucher([FromBody]InventoryDeliveryVoucherModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _inventoryDeliveryVoucherService.AddInventoryDeliveryVoucher(model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetInventoryDeliveryVoucherById/{inventoryDeliveryVoucherId}")]
        [HttpGet]
        public async Task<IActionResult> GetInventoryDeliveryVoucherByCode(Guid inventoryDeliveryVoucherId)
        {
            return Ok(await _inventoryDeliveryVoucherService.GetInventoryDeliveryVoucherById(inventoryDeliveryVoucherId));
        }
    }
}
