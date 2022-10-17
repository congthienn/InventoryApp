using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.DTO
{
    public class ResetPasswordRq
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordRq>
    {
        public ResetPasswordValidator()
        {
            
        }
        private bool IsValidPassword(string password)
        {
            Regex passwordRules = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{10,}$");
            return passwordRules.IsMatch(password);
        }
    }
}
