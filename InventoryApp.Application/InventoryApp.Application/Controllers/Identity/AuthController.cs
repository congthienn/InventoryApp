using InventoryApp.Common.ApiActionResult;
using InventoryApp.Domain.Identity.DTO;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Domain.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace InventoryApp.Application.Controllers.Identity
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IOptions<IdentityOptions> _identityOptions;
        public AuthController(IAuthService authService, IJwtTokenService jwtTokenService, IOptions<IdentityOptions> identityOptions)
        {
            _authService = authService;
            _jwtTokenService = jwtTokenService;
            _identityOptions = identityOptions;
        }

        [Route("signIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInModelRq signInModelRq)
        {
            var result = await _authService.SignInAsync(signInModelRq.Email, signInModelRq.Password, true);

            if (result.Succeeded)
                return Ok(_jwtTokenService.GenerateJwtToken(result.UserIdentity, result.Roles));

            if (result.IsLockedOut)
                return BadRequest($"User account locked out, max failed access attemps are {_identityOptions.Value.Lockout.MaxFailedAccessAttempts}");
            
            if (result.IsNotAllowed)
                return BadRequest("User account is not allowed, make sure your account have been verified");
            
            if (result.RequiresTwoFactor)
                return BadRequest("Two Factor Login is required");

            return BadRequest("Email or Password does not match");
        }
    }
}
