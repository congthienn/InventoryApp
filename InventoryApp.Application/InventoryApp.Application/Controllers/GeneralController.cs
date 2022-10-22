using InventoryApp.Data.Helper;
using InventoryApp.Domain.Services;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class GeneralController : BaseController
    {
        private readonly IGeneralService _generalService;
        public GeneralController(IGeneralService generalService)
        {
            _generalService = generalService;
        }

        [Route("companyInformation")]
        [HttpGet()]
        public CompanyModelRq GetCompanyInformation()
        {
            return _generalService.GetCompanyInformation();
        }

        [Route("companyInformation")]
        [HttpPost]
        public async Task<IActionResult> AddCompanyInformation([FromBody] CompanyModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _generalService.AddCompanyInformation(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("companyInformation")]
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyInformation([FromBody] CompanyUpdateModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _generalService.UpdateCompanyInformation(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("companyInformationIsEmpty")]
        [HttpGet]
        public async Task<IActionResult> CompanyInformationAlreadyExists()
        {
            return Ok(await _generalService.CompanyInformationAlreadyExists());
        }
    }
}
