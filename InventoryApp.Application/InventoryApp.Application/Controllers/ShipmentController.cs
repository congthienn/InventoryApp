using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class ShipmentController : BaseController
    {
        private readonly IShipmentService _shipmentService;
        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }
      
        [HttpPost]
        public async Task<IActionResult> AddShipment([FromBody]ShipmentModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _shipmentService.AddShipment(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("{shipmentId}")]
        public async Task<IActionResult> UpdateShipment(string shipmentId, ShipmentModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _shipmentService.UpdateShipment(shipmentId, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IEnumerable<ShipmentModelRq> GetAllShipments()
        {
            return _shipmentService.GetAllShipments();
        }

        [HttpDelete("{shipmentId}")]
        public async Task<IActionResult> DeleteShipment(string shipmentId)
        {
            try
            {
                return Ok(await _shipmentService.DeleteShipment(shipmentId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
