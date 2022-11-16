using FluentValidation;
using InventoryApp.Common.Helper;
using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class SupplierModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string SupplierName { get; set; }
        public string Code { get; private set; }
        public string CodeName { get; private set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string? LogoURL { get; set; }
        public string? WebsiteURL { get; set; }
        public string? FacebookName { get; set; }
        public bool Status { get; set; } = true;
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public ProvinceDTO Province { get; set; }
        public int DistrictId { get; set; }
        public DistrictDTO District { get; set; }
        public int WardId { get; set; }
        public WardDTO Ward { get; set; }
        public Guid SupplierGroupId { get; set; }
        public SupplierGroupModelRq SupplierGroup { get; set; }
    }
    public class SuppplierModelValidator : AbstractValidator<SupplierModelRq>
    {
        public SuppplierModelValidator()
        {
            RuleFor(p => p.SupplierName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.PhoneNumber).NotEmpty().Must(IdentityHelper.IsValidPhoneNumber);
            RuleFor(p => p.TaxCode).NotEmpty();
            RuleFor(p => p.Fax).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.ProvinceId).NotEmpty();
            RuleFor(p => p.DistrictId).NotEmpty();
            RuleFor(p => p.WardId).NotEmpty();
            RuleFor(p => p.SupplierGroupId).NotEmpty();
        }
    }
}
