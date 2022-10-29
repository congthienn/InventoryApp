using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class MaterialAttributeController : BaseController
    {
        private readonly IMaterialAttributeService _materialAttributeService;
        public MaterialAttributeController(IMaterialAttributeService materialAttributeService)
        {
            _materialAttributeService = materialAttributeService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddMaterialAttribute([FromBody]MaterialAttributeModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialAttributeService.AddMaterialAttribute(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialAttribute(int id, [FromBody]MaterialAttributeModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialAttributeService.UpdateMaterialAttribute(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialAttribute(int id)
        {
            try
            {
                return Ok(await _materialAttributeService.DeleteMaterialAttribute(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
