using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class UserBranchController : BaseController
    {
        private readonly IUserBranchService _userBranchService;
        public UserBranchController(IUserBranchService userBranchService)
        {
            _userBranchService = userBranchService;
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBranchToUser([FromBody]UserBranchModelRq model)
        {
            try
            {
                return Ok(await _userBranchService.UpdateBranchToUser(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBranchToUser([FromBody]UserBranchModelRq model)
        {
            try
            {
                return Ok(await _userBranchService.DeleteBranchToUser(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getUser/{branchId}")]
        [HttpGet]
        public IEnumerable<string> GetAllUsersOfTheBranch(Guid branchId)
        {
            return _userBranchService.GetAllUsersOfTheBranch(branchId);
        }

        [Route("getBranch/{userId}")]
        [HttpGet]
        public IEnumerable<string> GetAllBranchOfTheUser(Guid userId)
        {
            return _userBranchService.GetAllBranchOfTheUser(userId);
        }
    }
}
