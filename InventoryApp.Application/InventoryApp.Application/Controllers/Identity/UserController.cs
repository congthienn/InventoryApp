using InventoryApp.Data.Helper;
using InventoryApp.Domain.Identity.DTO.Roles;
using InventoryApp.Domain.Identity.DTO.Users;
using InventoryApp.Domain.Identity.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers.Identity
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserModelRq> GetUserList()
        {
            return _userService.GetUserList();
        }

        [Route("{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            return Ok(await  _userService.GetUserById(userId));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody]UserModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _userService.AddUserAsync(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(Guid id, [FromBody] UserUpdateRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _userService.UpdateUserAsync(id, model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            try
            {
                return Ok(await _userService.DeleteUserAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("updateRole")]
        [HttpPost]
        public async Task<IActionResult> UpdateRoleToUserAsync([FromBody]UserRoleModelRq model)
        {
            try
            {
                return Ok(await _userService.UpdateRoleToUserAsync(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getRole/{userId}")]
        [HttpGet]
        public IEnumerable<RoleModelRq> GetRoleByUser(Guid userId)
        {
            return _userService.GetRoleByUser(userId);
        }

        [Route("deleteRole")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoleToUserAsync([FromBody]UserRoleModelRq model)
        {
            try
            {
                return Ok(await _userService.RemoveRoleToUserAsync(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [Route("confirmEmail")]
        [HttpPost]
        public async Task<IActionResult> ActivateUserAccount([FromBody]ConfirmEmailModelRq model)
        {
            try
            {
                return Ok(await _userService.ActivateUserAccount(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message); ;
            }
        }

        [Route("updateAccountStatus")]
        [HttpPut]
        public async Task<IActionResult> UpdateAccountStatus([FromBody]UpdateAccountStatusModelRq model)
        {
            try
            {
                return Ok(await _userService.UpdateAccountStatus(model));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
