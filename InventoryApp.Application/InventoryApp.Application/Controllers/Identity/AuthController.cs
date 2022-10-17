using InventoryApp.Common.ApiActionResult;
using InventoryApp.Data.Helper;
using InventoryApp.Domain.Identity.DTO;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Domain.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace InventoryApp.Application.Controllers.Identity
{
    public class AuthController : BaseController
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

        [Authorize]
        [Route("changePassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] UserChangePasswordRq model)
        {
            try
            {
                UserIdentity issuer = GetCurrentUserIdentity();
                return Ok(await _authService.ChangePasswordAsync(model, issuer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("forgotPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] UserForgotPasswordRq model)
        {
            try
            {
                return Ok(await _authService.ForgotPasswordAsync(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("passwordReset")]
        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRq model)
        {
            try
            {
                return Ok(await _authService.ResetPasswordAsync(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [Route("checkPassword")]
        [HttpPost]
        public async Task<IActionResult> CheckUserPassword([FromBody] UserCheckPasswordRq model)
        {
            try
            {
                UserIdentity issuer = GetCurrentUserIdentity();
                return Ok(await _authService.CheckExistUserPasswordAsync(issuer.Id, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
