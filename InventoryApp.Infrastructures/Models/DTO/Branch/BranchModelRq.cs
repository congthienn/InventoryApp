using FluentValidation;
using InventoryApp.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class BranchModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string CompanyName { get; set; }
        public string Code { get; private set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public ProvinceDTO Province { get; private set; }
        public int DistrictId { get; set; }
        public DistrictDTO District { get; private set; }
        public int WardId { get; set; }
        public WardDTO Ward { get; private set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string? LogoURL { get; set; }
        public string? WebsiteURL { get; set; }
        public string? FacebookName { get; set; }
        public Guid CompaniesId { get; set; }
        public bool BranchMain { get; set; } = false;
    }
    public class BranchModelValidator : AbstractValidator<BranchModelRq>
    {
        public BranchModelValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
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
