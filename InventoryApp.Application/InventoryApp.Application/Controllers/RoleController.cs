using InventoryApp.Data.Helper;
using InventoryApp.Domain.Identity.DTO.Roles;
using InventoryApp.Domain.Identity.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IEnumerable<RoleModelRq> GetRoleList()
        {
            return _roleService.GetRoleList();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            return Ok(await _roleService.GetRoleById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync([FromBody] RoleModelRq model)
        {
            try
            {
                UserIdentity user = GetCurrentUserIdentity();
                return Ok(await _roleService.AddRoleAsync(model, user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoleAsync(Guid id, [FromBody] RoleModelRq model)
        {
            try
            {
                UserIdentity user = GetCurrentUserIdentity();
                return Ok(await _roleService.UpdateRoleAsync(id, model, user));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoleAsync(Guid id)
        {
            try
            {
                return Ok(await _roleService.DeleteRoleAsync(id));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("roleByName")]
        [HttpGet]
        public async Task<IActionResult> GetRoleByName([FromBody]RoleModelRq model)
        {
            return Ok(await _roleService.GetRoleByName(model.Name));
        }

        [Route("roleByUser/{userId}")]
        [HttpGet]
        public IQueryable GetListUserRole(Guid userId)
        {
            return _roleService.GetListUserRole(userId);
        }
    }
}
