using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class EmployeeModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; private set; }
        public bool Sex { get; set; }
        public string Email { get; set; }
        public string IdentityCard { get; set; }
        public string CardImage { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid BranchId { get; set; }
        public bool Status { get; private set; } = true;
        public BranchModelRq Branch { get; set; }
        public int ProvinceId { get; set; }
        public ProvinceDTO Province { get; set; }
        public int DistrictId { get; set; }
        public DistrictDTO District { get; set; }
        public int WardId { get; set; }
        public WardDTO Ward { get; set; }
        public IFormFile Image { get; set; }
    }
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.Sex).NotEmpty();
            RuleFor(p => p.IdentityCard).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.ProvinceId).NotEmpty();
            RuleFor(p => p.DistrictId).NotEmpty();
            RuleFor(p => p.WardId).NotEmpty();
            RuleFor(p => p.BranchId).NotEmpty();
            RuleFor(p => p.Image).NotEmpty();
        }
    }
}
