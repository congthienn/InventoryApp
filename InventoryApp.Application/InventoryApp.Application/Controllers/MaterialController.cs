using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
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
        public async Task<IActionResult> AddMaterial([FromForm]MaterialModelRq model, [FromForm]List<MaterialAttributeValueModel> AttributeValue)
        {
            try
            {
                AttributeValue.Add(new MaterialAttributeValueModel()
                {
                    MaterialAttributeId = 6,
                    Value = "128 GB"
                });
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialService.AddMaterial(model, AttributeValue, userIdentity));
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

        [Route("picture/{pictureId}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePictureById(int pictureId)
        {
            try
            {
                return Ok(await _materialService.DeleteMaterialPictureById(pictureId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{materialId}")]
        public async Task<IActionResult> UpdateMaterial(Guid materialId, [FromForm]MaterialModelRq model, [FromForm]List<MaterialAttributeValueModel> AttributeValue, List<IFormFile> Prictures)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialService.UpdateMaterial(materialId, model, AttributeValue, Prictures, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{materialId}/setStatus")]
        [HttpPut]
        public async Task<IActionResult> SetMaterialStatus(Guid materialId,[FromBody] StatusModel status)
        {
            UserIdentity userIdentity = GetCurrentUserIdentity();
            return Ok(await _materialService.SetMaterialStatus(materialId, status, userIdentity));
        }

        [Route("{materialId}/GetAttributeValue")]
        [HttpGet]
        public async Task<IEnumerable<ShowMaterialAttributeValue>> GetMaterialAttributeValue(Guid materialId)
        {
            return await _materialService.GetMaterialAttributeValue(materialId);
        }

        [Route("addPosition")]
        [HttpPost]
        public async Task<IActionResult> AddMaterialPosition([FromBody] MaterialPositionModel model)
        {
            try
            {
                return Ok(await _materialService.AddMaterialPosition(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("updatePosition/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMaterialPosition(int id, [FromBody] MaterialPositionModel model)
        {
            try
            {
                return Ok(await _materialService.UpdateMaterialPosition(id, model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetMaterialPositionsByBranchId/{branchId}")]
        [HttpGet]
        public IEnumerable<ShowMaterialPosition> GetMaterialPositionsByBranchId(Guid branchId)
        {
            return _materialService.GetMaterialPositionsByBranchId(branchId);
        }

        [Route("GetMaterialQuantityByMaterialIdAndBranchId/{materialId}/{branchId}")]
        [HttpGet]
        public async Task<IActionResult> GetMaterialQuantityByMaterialIdAndBranchId(Guid branchId, Guid materialId)
        {
            return Ok(await _materialService.GetMaterialQuantityByMaterialIdAndBranchId(materialId, branchId));
        }
    }
}
