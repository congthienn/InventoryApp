using FluentValidation;
using InventoryApp.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class CompanyUpdateModelRq
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string? AppelationOfForeignTrader { get; set; }
        public string? ForeignName { get; set; }
        public string? ShortName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? LogoURL { get; set; }
        public string? WebsiteURL { get; set; }
        public string? FacebookName { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
    }

    public class CompanyUpdateModelValidator : AbstractValidator<CompanyUpdateModelRq>
    {
        public CompanyUpdateModelValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.PhoneNumber).NotEmpty().Must(IdentityHelper.IsValidPhoneNumber);
        }
    }
}
