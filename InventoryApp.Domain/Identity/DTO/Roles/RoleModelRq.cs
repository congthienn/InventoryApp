using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.DTO.Roles
{
    public class RoleModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
    public class RoleUpdatedModelValidator : AbstractValidator<RoleModelRq>
    {
        public RoleUpdatedModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Please enter the role name");
        }
    }
}
