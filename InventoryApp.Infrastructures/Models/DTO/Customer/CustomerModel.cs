using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class CustomerModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string CustomerName { get; set; }
        public string Code { get; private set; }
        public string CodeName { get; private set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Fax { get; set; }
        public string TaxCode { get; set; }
        public string? LogoURL { get; set; }
        public string? WebsiteURL { get; set; }
        public string? FacebookName { get; set; }
        public bool Status { get; set; } = true;
        public Guid CustomerGroupId { get; set; }
        public CustomerGroupModel CustomerGroup { get; set; }
        public Guid BranchId { get; set; }
        public BranchModelRq Branch { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public ProvinceDTO Province { get; set; }
        public int DistrictId { get; set; }
        public DistrictDTO District { get; set; }
        public int WardId { get; set; }
        public WardDTO Ward { get; set; }
    }
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(p=>p.CustomerName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.ProvinceId).NotEmpty();
            RuleFor(p => p.DistrictId).NotEmpty();
            RuleFor(p => p.WardId).NotEmpty();
            RuleFor(p => p.CustomerGroupId).NotEmpty();
            RuleFor(p => p.BranchId).NotEmpty();
        }
    }
}
