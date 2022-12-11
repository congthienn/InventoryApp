using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    public class DeliveryCompanyController : BaseController
    {
        private readonly IDeliveryCompanyService _deliveryCompanyService;
        public DeliveryCompanyController(IDeliveryCompanyService deliveryCompanyService)
        {
            _deliveryCompanyService = deliveryCompanyService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDeliveryCompany([FromBody]DeliveryCompanyModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _deliveryCompanyService.AddDeliveryCompany(model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("GetAllDeliveryCompanyByBranchId/{branchId}")]
        [HttpGet]
        public IEnumerable<DeliveryCompanyModel> GetAllDeliveryCompanyByBranchId(Guid branchId)
        {
            return _deliveryCompanyService.GetAllDeliveryCompanyByBranchId(branchId);
        }
    }
}
