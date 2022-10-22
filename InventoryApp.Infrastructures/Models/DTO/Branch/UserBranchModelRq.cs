using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class UserBranchModelRq
    {
        public Guid UserId { get; set; }
        public Guid BranchId { get; set; }
    }
    public class UserBranchModelValidator : AbstractValidator<UserBranchModelRq>
    {
        public UserBranchModelValidator()
        {
            RuleFor(p => p.BranchId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
