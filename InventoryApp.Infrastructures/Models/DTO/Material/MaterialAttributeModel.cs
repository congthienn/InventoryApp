using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class MaterialAttributeModel
    {
        public int MaterialAttributeId { get; private set; }
        public string Name { get; set; }
        public Guid MaterialsCategoryId { get; set; }
    }

    public class MaterialAttributeModelValidator : AbstractValidator<MaterialAttributeModel>
    {
        public MaterialAttributeModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.MaterialsCategoryId).NotEmpty();
        }
    }
}
