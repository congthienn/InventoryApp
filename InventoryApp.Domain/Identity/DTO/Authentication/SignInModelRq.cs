using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.DTO
{
    public class SignInModelRq
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class SignInModelValidator : AbstractValidator<SignInModelRq>
    {
        public SignInModelValidator()
        {
            RuleFor(p => p.Email).Restrict(RestrictMode.StopOnFirstFailure).NotEmpty().WithMessage("Please enter your login email");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Email address is not valid");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Please enter the login password");
        }
    }
}
