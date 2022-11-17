using FluentValidation;
using InventoryApp.Common.Helper;

namespace InventoryApp.Domain.Identity.DTO
{
    public class ResetPasswordRq
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }

        public string ReNewPassword { get; set; }
    }
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordRq>
    {
        public ResetPasswordValidator()
        {
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Please enter a new password")
                                                    .Must(IdentityHelper.IsValidPassword).WithMessage("Invalid password");
            RuleFor(p => p.ReNewPassword).Restrict(RestrictMode.StopOnFirstFailure).Equal(p => p.NewPassword).WithMessage("Password and Re-password are not match");
        }
    }
}
