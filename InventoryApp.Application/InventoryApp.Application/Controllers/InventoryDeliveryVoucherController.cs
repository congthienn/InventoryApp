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

        [Route("Code/{code}")]
        [HttpGet]
        public async Task<IActionResult> GetInventoryDeliveryVoucherByCode(string code)
        {
            return Ok(await _inventoryDeliveryVoucherService.GetInventoryDeliveryVoucherByCode(code));
        }

        [Route("Status/{status}")]
        [HttpGet]
        public IEnumerable<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCodeByStatus(int status)
        {
            return _inventoryDeliveryVoucherService.GetInventoryDeliveryVoucherByCodeByStatus(status);
        }

        [Route("Purpose/{purpose}")]
        [HttpGet]
        public IEnumerable<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCodeByPurpose(int purpose)
        {
            return _inventoryDeliveryVoucherService.GetInventoryDeliveryVoucherByCodeByPurpose(purpose);
        }

        [HttpPut("Approve/{code}")]
        public async Task<IActionResult> ApproveInventoryDeliveryVoucher(string code, [FromBody]OrderStatusModel statusModel)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _inventoryDeliveryVoucherService.ApproveInventoryDeliveryVoucher(code, statusModel, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ConfirmGoodsIssueDate/{code}")]
        [HttpPut]
        public async Task<IActionResult> ConfirmGoodsIssueDate(string code)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _inventoryDeliveryVoucherService.ConfirmGoodsIssueDate(code, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
