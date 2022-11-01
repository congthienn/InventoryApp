using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class MaterialPositionModel
    {
        public Guid MaterialId { get; set; }   
        public Guid BrachId { get; set; } 
        public Guid WarehouseShelveId { get; set; }
    }
    public class MaterialPositionModelValidator : AbstractValidator<MaterialPositionModel>
    {
        public MaterialPositionModelValidator()
        {
            RuleFor(p => p.MaterialId).NotEmpty();
            RuleFor(p => p.BrachId).NotEmpty();
            RuleFor(p => p.WarehouseShelveId).NotEmpty();
        }
    }
}
