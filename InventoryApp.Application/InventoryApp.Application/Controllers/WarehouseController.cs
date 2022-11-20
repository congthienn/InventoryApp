using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class WarehouseController : BaseController
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        [HttpGet]
        public IEnumerable<WarehouseModel> GetAllWarehouses()
        {
            return _warehouseService.GetAllWarehouses();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseById(Guid id)
        {
            return Ok(await _warehouseService.GetWarehouseById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddWarehouse([FromBody]WarehouseModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseService.AddWarehouse(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouse(Guid id, WarehouseModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _warehouseService.UpdateWarehouse(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(Guid id)
        {
            try
            {
                return Ok(await _warehouseService.DeleteWarehouse(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{warehouseId}/GetAllWarehouseArea")]
        [HttpGet]
        public IEnumerable<WarehouseAreaModel> GetAllWarehouseAreas(Guid warehouseId)
        {
            return _warehouseService.GetAllWarehouseAreas(warehouseId);
        }

        [Route("GetAllWarehouseByBranchId/{branchId}")]
        [HttpGet]
        public IEnumerable<WarehouseModel> Get(Guid branchId)
        {
            return _warehouseService.GetAllWarehouseByBranchId(branchId);
        }
    }
}
