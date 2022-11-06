using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class MaterialQuotationController : BaseController
    {
        private readonly IMaterialQuotationService _materialQuotationService;
        public MaterialQuotationController(IMaterialQuotationService materialQuotationService)
        {
            _materialQuotationService = materialQuotationService;
        }

        [Route("Material/{materialId}")]
        [HttpGet]
        public IEnumerable<MaterialQuotationModel> GetAllMaterialQuotationByMaterialId(Guid materialId)
        {
            return _materialQuotationService.GetAllMaterialQuotationByMaterialId(materialId);
        }

        [Route("Material/{materialId}/{quantity}")]
        [HttpGet]
        public async Task<IActionResult> GetMaterialQuotationByMaterialIdAndQuantity(Guid materialId, int quantity)
        {
            return Ok(await _materialQuotationService.GetMaterialQuotationByMaterialIdAndQuantity(materialId, quantity));
        }
        [HttpPost]
        public async Task<IActionResult> AddMaterialQuotation([FromBody]MaterialQuotationModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialQuotationService.AddMaterialQuotation(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{code}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMaterialQuotation(string code, [FromBody]MaterialQuotationModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialQuotationService.UpdateMaterialQuotation(code, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{code}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMaterialQuotation(string code)
        {
            try
            {
                return Ok(await _materialQuotationService.DeleteMaterialQuotation(code));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
