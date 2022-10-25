using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class MaterialUnitController : BaseController
    {
        private readonly IMaterialUnitService _materialUnitService;
        public MaterialUnitController(IMaterialUnitService materialUnitService)
        {
            _materialUnitService = materialUnitService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterialUnit(MaterialUnitModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialUnitService.AddMaterialUnit(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialUnit(Guid id, MaterialUnitModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialUnitService.UpdateMaterialUnit(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialUnit(Guid id)
        {
            try
            {
                return Ok(await _materialUnitService.DeleteMaterialUnit(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
