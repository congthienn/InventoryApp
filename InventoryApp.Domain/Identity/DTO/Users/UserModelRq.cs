using FluentValidation;
using InventoryApp.Common.Helper;
using InventoryApp.Domain.Helper;

namespace InventoryApp.Domain.Identity.DTO.Users
{
    public class UserModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? AvatarURL { get; set; }
        public bool Status { get; private set; } = false;
    }
    public class UserModelValidator : AbstractValidator<UserModelRq>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.PhoneNumber).Must(IdentityHelper.IsValidPhoneNumber).WithMessage("Invalid phone number");
        }
    }
}
