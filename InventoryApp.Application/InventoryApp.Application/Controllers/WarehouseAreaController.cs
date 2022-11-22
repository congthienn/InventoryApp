using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class WarehouseAreaController : BaseController
    {
        private readonly IWarehouseAreaService _warehouseAreaService;
        public WarehouseAreaController(IWarehouseAreaService warehouseAreaService)
        {
            _warehouseAreaService = warehouseAreaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseAreaById(Guid id)
        {
            return Ok(await _warehouseAreaService.GetWarehouseAreaById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddWarehouseArea([FromBody]WarehouseAreaModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseAreaService.AddWarehouseArea(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouseArea(Guid id,[FromBody] WarehouseAreaModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseAreaService.UpdateWarehouseArea(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouseArea(Guid id)
        {
            try
            {
                return Ok(await _warehouseAreaService.DeleteWarehouseArea(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}/GetAllWarehouseLine")]
        [HttpGet]
        public IEnumerable<WarehouseLineModel> GetWarehouseLine(Guid id)
        {
            return _warehouseAreaService.GetWarehouseLine(id);
        }

        [Route("GetAllWarehouseAreaByWarehouseId/{warehouseId}")]
        [HttpGet]
        public IEnumerable<WarehouseAreaModel> GetAllWarehouseAreaByWarehouseId(Guid warehouseId)
        {
            return _warehouseAreaService.GetAllWarehouseAreaByWarehouseId(warehouseId);
        }
        
    }
}
