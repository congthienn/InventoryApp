using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ReturnedMaterialDetailModel
    {
        public int ReturnedMaterialId { get; set; }
        public ReturnedMaterialModel ReturnedMaterial { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialModelRq Material { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public class ReturnedMaterialDetailModelValidator : AbstractValidator<ReturnedMaterialDetailModel>
    {
        public ReturnedMaterialDetailModelValidator()
        {
            RuleFor(p => p.MaterialId).NotEmpty();
            RuleFor(p => p.Quantity).NotEmpty();
        }
    }
}
