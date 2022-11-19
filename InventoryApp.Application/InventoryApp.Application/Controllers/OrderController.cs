using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderModel> GetAllOrder()
        {
            return _orderService.GetAllOrder();
        }

        [Route("Code/{code}")]
        [HttpGet()]
        public async Task<IActionResult> GetOrderByCode(string code)
        {
            return Ok(await _orderService.GetOrderByCode(code));
        }

        [Route("Status/{status}")]
        [HttpGet()]
        public IEnumerable<OrderModel> GetAllOrderByStatus(int status)
        {
            return _orderService.GetAllOrderByStatus(status);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody]OrderModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _orderService.AddOrder(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateOrder(string code, [FromBody]OrderModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _orderService.UpdateOrder(code, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("updateStatus/{code}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatusOrder(string code)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _orderService.UpdateStatusOrder(code, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("orderDetail/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            try
            {
                return Ok(await _orderService.DeleteOrderDetail(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
