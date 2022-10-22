using FluentValidation;
using InventoryApp.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class BranchUpdateModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CodeName { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string? LogoURL { get; set; }
        public string? WebsiteURL { get; set; }
        public string? FacebookName { get; set; }
        public Guid CompaniesId { get; set; }
        public bool BranchMain { get; set; } = false;
    }
    public class BranchUpdateModelValidator : AbstractValidator<BranchUpdateModel>
    {
        public BranchUpdateModelValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Fax).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty().Must(IdentityHelper.IsValidPhoneNumber);
        }
    }
}
