using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class MaterialUnitModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int ExchangeValue { get; set; }
        public Guid MaterialId { get; set; }
        public int Price { get; set; }
        public bool DirectSales { get; set; } = true;
    }
    public class MaterialUnitModelValidator : AbstractValidator<MaterialUnitModelRq>
    {
        public MaterialUnitModelValidator()
        {
            RuleFor(p=>p.Name).NotEmpty();
            RuleFor(p => p.ExchangeValue).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
        }
    }
}
