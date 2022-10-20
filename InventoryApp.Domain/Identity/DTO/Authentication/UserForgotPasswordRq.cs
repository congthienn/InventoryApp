
using FluentValidation;

namespace InventoryApp.Domain.Identity.DTO
{
    public class UserForgotPasswordRq
    {
        public string Email { get; set; }
    }
    public class UserForgotPasswordValidator : AbstractValidator<UserForgotPasswordRq>
    {
        public UserForgotPasswordValidator()
        {
            RuleFor(p => p.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Please enter your login email");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Email address is not valid");
        }
    }
}
