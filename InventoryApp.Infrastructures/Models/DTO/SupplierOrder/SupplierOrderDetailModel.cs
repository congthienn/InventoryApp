using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class SupplierOrderDetailModel
    {
        public int Id { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialModelRq Material { get; set; }
        public int QuantityRequest { get; set; }
        public int MaterialPrice { get; set; }
    }
    public class SupplierOrderDetailModelValidator : AbstractValidator<SupplierOrderDetailModel>
    {
        public SupplierOrderDetailModelValidator()
        {
            RuleFor(p => p.MaterialId).NotEmpty();
            RuleFor(p => p.QuantityRequest).NotEmpty();
        }
    }
}
