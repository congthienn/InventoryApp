using FluentValidation;
using InventoryApp.Common.Helper;
using InventoryApp.Domain.Helper;

namespace InventoryApp.Domain.Identity.DTO.Users
{
    public class UserUpdateRq
    {
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public string? AvatarURL { get; set; }
    }

    public class UserUpdateValidator : AbstractValidator<UserUpdateRq>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.PhoneNumber).Length(10).Must(IdentityHelper.IsValidPhoneNumber).WithMessage("Invalid phone number");
        }
    }
}
