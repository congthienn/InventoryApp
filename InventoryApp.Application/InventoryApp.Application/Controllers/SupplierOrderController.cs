using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class SupplierOrderController : BaseController
    {
        private readonly ISupplierOrderService _supplierOrderService;
        public SupplierOrderController(ISupplierOrderService supplierOrderService)
        {
            _supplierOrderService = supplierOrderService;
        }
        [HttpGet]
        public IEnumerable<SupplierOrderModel> GetAllSupplierOrder()
        {
            return _supplierOrderService.GetAllSupplierOrder();
        }

        [Route("Code/{code}")]
        [HttpGet()]
        public async Task<IActionResult> GetSupplierOrderByCode(string code)
        {
            return Ok(await _supplierOrderService.GetSupplierOrderByCode(code));
        }

        [Route("Status/{status}")]
        [HttpGet()]
        public IEnumerable<SupplierOrderModel> GetAllSupplierOrderByStatus(int status)
        {
            return _supplierOrderService.GetAllSupplierOrderByStatus(status);
        }
        [HttpPost]
        public async Task<IActionResult> AddSupplierOrder([FromBody] SupplierOrderModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _supplierOrderService.AddSupplierOrder(model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateSupplierOrder(string code, [FromBody] SupplierOrderModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _supplierOrderService.UpdateSupplierOrder(code, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("updateStatus/{code}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatusSupplierOrder(string code)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _supplierOrderService.UpdateStatusSupplierOrder(code, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("orderDetail/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplierOrderDetail(int id)
        {
            try
            {
                return Ok(await _supplierOrderService.DeleteSupplierOrderDetail(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
