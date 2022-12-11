using FluentValidation;
using InventoryApp.Common.Helper;
using InventoryApp.Data.Models;

using InventoryApp.Domain.Helper;
using InventoryApp.Domain.Identity.DTO.Roles;
using InventoryApp.Infrastructures.Models.DTO;

namespace InventoryApp.Domain.Identity.DTO.Users
{
    public class UserModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Employee { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? AvatarURL { get; set; }
        public bool Status { get; private set; } = true;
        public List<Guid> BranchId { get; set; }
        public IEnumerable<BranchModelRq> Branch { get; set; }
        public Guid RoleId { get; set; }
        public RoleModelRq Role { get; set; }
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
