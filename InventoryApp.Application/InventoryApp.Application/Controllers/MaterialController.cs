using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class MaterialController : BaseController
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMaterial([FromForm]MaterialModelRq model, List<IFormFile> Prictures)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialService.AddMaterial(model, Prictures, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IEnumerable<ShowMaterialModel> GetAllMaterials() 
        {
            return _materialService.GetAllMaterials();
        }


        [HttpGet("{materialId}")]
        public async Task<IActionResult> GetMaterialById(Guid materialId)
        {
            return Ok(await _materialService.GetMaterialById(materialId));
        }

        [HttpDelete("{materialId}")]
        public async Task<IActionResult> DeleteMaterial(Guid materialId)
        {
            try
            {
                return Ok(await _materialService.DeleteMaterial(materialId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
