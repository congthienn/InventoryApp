using InventoryApp.Data.Models;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Domain.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        public AuthService(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
    }
}
