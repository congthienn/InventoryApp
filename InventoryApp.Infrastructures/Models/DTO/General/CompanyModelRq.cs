using FluentValidation;
using InventoryApp.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class CompanyModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string CompanyName { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string? LogoURL { get; set; }
        public string? WebsiteURL { get; set; }
        public string? FacebookName { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
    }

    public class CompanyModelValidator : AbstractValidator<CompanyModelRq>
    {
        public CompanyModelValidator()
        {
            RuleFor(p=>p.CompanyName).NotEmpty();
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p=>p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.PhoneNumber).NotEmpty().Must(IdentityHelper.IsValidPhoneNumber);
            RuleFor(p => p.TaxCode).NotEmpty();
            RuleFor(p => p.Fax).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.ProvinceId).NotEmpty();
            RuleFor(p => p.DistrictId).NotEmpty();
            RuleFor(p => p.WardId).NotEmpty();
        }
    }

}
