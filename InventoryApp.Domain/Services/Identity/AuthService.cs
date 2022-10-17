using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Identity.DTO;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Domain.Identity.Models;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly IEmailService _emailService;
        public AuthService(SignInManager<Users> signInManager, UserManager<Users> userManager, ILogger<AuthService> logger, IEmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<SignInModel> SignInAsync(string email, string password, bool lockoutOnFailure)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new SignInModel { Succeeded = false };

            var signInResult = new SignInModel(await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure));
            if (!signInResult.Succeeded)
                return signInResult;

            signInResult.Roles = await _userManager.GetRolesAsync(user);
            signInResult.UserIdentity = new Users { Id = user.Id, UserName = user.UserName };
            signInResult.AvatarURL = user.AvatarURL ?? "";
            return signInResult;
        }
        public async Task<bool> ChangePasswordAsync(UserChangePasswordRq model, UserIdentity issuer)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(issuer.Id.ToString());
                if (user == null)
                    return false;

                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                if (!result.Succeeded)
                    return false;

                user.UpdateBy(issuer);
                await _userManager.UpdateAsync(user);
                await _emailService.SendEmailChangePasswordAsync(user.Email, user.UserName);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> ForgotPasswordAsync(UserForgotPasswordRq model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return false;

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            await _emailService.SendEmailForgotPasswordAsync(user.Email, user.UserName, token);
            return true;
        }

        public async  Task<bool> ResetPasswordAsync(ResetPasswordRq model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return false;

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

                if (!result.Succeeded)
                    return false;

                await _userManager.UpdateAsync(user);
                await _emailService.SendEmailChangePasswordAsync(user.Email, user.UserName);

                return true;
                
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> CheckExistUserPasswordAsync(Guid id, UserCheckPasswordRq model)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return await _userManager.CheckPasswordAsync(user, model.Password);       
        }
    }
}
