using FluentValidation;
using InventoryApp.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.DTO.Users
{
    public class ConfirmEmailModelRq
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
    public class ConfirmEmailModelValidator : AbstractValidator<ConfirmEmailModelRq>
    {
        public ConfirmEmailModelValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
        }
    }
}
