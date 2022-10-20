using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.DTO.Users
{
    public class UserRoleModelRq
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }

    public class UserRoleModelValidator : AbstractValidator<UserRoleModelRq>
    {
        public UserRoleModelValidator()
        {
            RuleFor(p => p.RoleId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
