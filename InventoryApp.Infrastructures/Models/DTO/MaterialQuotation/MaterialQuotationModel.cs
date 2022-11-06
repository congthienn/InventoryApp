using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class MaterialQuotationModel
    {
        public string Code { get; private set; }
        public Guid MaterialId { get; set; }
        public int CostPrice { get; set; }
        public int MinimumQuantity { get; set; }
        public int MaximumQuantity { get; set; }
    }
    public class MaterialQuotationModelValidator : AbstractValidator<MaterialQuotationModel>
    {
        public MaterialQuotationModelValidator()
        {
            RuleFor(p=>p.MaterialId).NotEmpty();
            RuleFor(p => p.CostPrice).NotEmpty();
            RuleFor(p => p.MinimumQuantity).NotEmpty();
            RuleFor(p => p.MaximumQuantity).NotEmpty();
            RuleFor(p => p.MaximumQuantity).GreaterThan(p=>p.MinimumQuantity).WithMessage("Valid quantity");
        }
    }
}
