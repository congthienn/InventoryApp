using InventoryApp.Data.Helper;
using InventoryApp.Domain.Identity.DTO;
using InventoryApp.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.IServices
{
    public interface IAuthService
    {
        Task<SignInModel> SignInAsync(string email, string password, bool lockoutOnFailure);
        Task<bool> ChangePasswordAsync(UserChangePasswordRq model, UserIdentity issuer);
        Task<bool> ForgotPasswordAsync(UserForgotPasswordRq model);
        Task<bool> ResetPasswordAsync(ResetPasswordRq model);
        Task<bool> CheckExistUserPasswordAsync(Guid id, UserCheckPasswordRq model);
    }
}
