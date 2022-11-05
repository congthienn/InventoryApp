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
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public IEnumerable<BranchModelRq> GetAllBranches()
        {
            return _branchService.GetAllBranches();
        }

        [HttpGet("{branchId}")]
        public async Task<IActionResult> GetBranchById(Guid branchId)
        {
            return Ok(await _branchService.GetBranchById(branchId));
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody]BranchModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _branchService.AddBranch(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBranch(BranchUpdateModel model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _branchService.UpdateBranch(model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            try
            {
                return Ok(await _branchService.DeleteBranch(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("mainBranchAlreadyExists")]
        [HttpGet]
        public async Task<IActionResult> MainBranchAlreadyExists()
        {
            return Ok(await _branchService.MainBranchAlreadyExists());
        }

        [Route("{branchId}/getShipment")]
        [HttpGet]
        public IEnumerable<ShipmentModelRq> GetAllShipmentByBranch(Guid branchId)
        {
            return _branchService.GetAllShipmentByBranch(branchId);
        }
    }
}
