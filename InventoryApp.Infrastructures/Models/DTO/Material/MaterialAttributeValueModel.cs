using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class MaterialAttributeValueModel
    {
        public int MaterialAttributeId { get; set; }
        public string Value { get; set; }
    }
    public class MaterialAttributeValueModelValidator : AbstractValidator<MaterialAttributeValueModel>
    {
        public MaterialAttributeValueModelValidator()
        {
            RuleFor(p=>p.MaterialAttributeId).NotEmpty();
            RuleFor(p => p.Value).NotEmpty();
        }
    }
}
