﻿using FluentValidation;
using System.Text.RegularExpressions;

namespace InventoryApp.Domain.Identity.DTO
{
    public class UserChangePasswordRq
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }
    }
    public class ChangePasswordModelValidator : AbstractValidator<UserChangePasswordRq>
    {
        public ChangePasswordModelValidator()
        {
            RuleFor(p => p.OldPassword).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Old password cannot be blank");
            RuleFor(p => p.NewPassword).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                                        .WithMessage("Please enter a new password").Must(IsValidPassword).WithMessage("Invalid password");
            RuleFor(p => p.ReNewPassword).Cascade(CascadeMode.StopOnFirstFailure).Equal(p => p.NewPassword).WithMessage("Password and Re-password are not match");
            RuleFor(p => p.ReNewPassword).NotEmpty().WithMessage("Please confirm new password");
            
        }
        private bool IsValidPassword(string password)
        {
            Regex passwordRules = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10,}$");
            return passwordRules.IsMatch(password);
        }
    }
}
