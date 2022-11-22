using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class WarehouseLineController : BaseController
    {
        private readonly IWarehouseLineService _warehouseLineService;
        public WarehouseLineController(IWarehouseLineService warehouseLineService)
        {
            _warehouseLineService = warehouseLineService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseLineById(Guid id)
        {
            return Ok(await _warehouseLineService.GetWarehouseLineById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddWarehouseLine([FromBody]WarehouseLineModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseLineService.AddWarehouseLine(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouseLine(Guid id,[FromBody] WarehouseLineModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseLineService.UpdateWarehouseLine(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouseLine(Guid id)
        {
            try
            {
                return Ok(await _warehouseLineService.DeleteWarehouseLine(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{warehouseLineId}/GetAllWarehouseShelve")]
        public IEnumerable<WarehouseShelveModel> GetAllWarehouseShelve(Guid warehouseLineId)
        {
            return _warehouseLineService.GetAllWarehouseShelve(warehouseLineId);
        }

        [HttpGet("GetAllWarehouseLineByWarehouseAreaId/{warehouseAreaId}")]
        public IEnumerable<WarehouseLineModel> GetAllWarehouseLineByWarehouseAreaId(Guid warehouseAreaId)
        {
            return _warehouseLineService.GetAllWarehouseLine(warehouseAreaId);
        }
    }
}
