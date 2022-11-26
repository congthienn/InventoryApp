using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class WarehouseShelveController : BaseController
    {
        private readonly IWarehouseShelveService _warehouseShelveService;
        public WarehouseShelveController(IWarehouseShelveService warehouseShelveService)
        {
            _warehouseShelveService = warehouseShelveService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseShelveById(Guid id)
        {
            return Ok(await _warehouseShelveService.GetWarehouseShelveById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouseShelve([FromBody]WarehouseShelveModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseShelveService.AddWarehouseShelve(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouseShelve(Guid id, [FromBody]WarehouseShelveModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseShelveService.UpdateWarehouseShelve(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouseShelve(Guid id)
        {
            try
            {
                return Ok(await _warehouseShelveService.DeleteWarehouseShelve(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
        [Route("GetWarehouseShelveByWarehouseLineId/{warehouseLineId}")]
        [HttpGet]
        public IEnumerable<WarehouseShelveModel> GetWarehouseShelveByWarehouseLineId(Guid warehouseLineId)
        {
            return _warehouseShelveService.GetWarehouseShelveByWarehouseLineId(warehouseLineId);
        }

        [Route("GetWarehouseShelveNoHasProductByWarehouseLineId/{warehouseLineId}")]
        [HttpGet]
        public IEnumerable<WarehouseShelveModel> GetWarehouseShelveNoHasProductByWarehouseLineId(Guid warehouseLineId)
        {
            return _warehouseShelveService.GetWarehouseShelveNoHasProductByWarehouseLineId(warehouseLineId);
        }
    }
}
