using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class SupplierGroupModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SupplierGroupModelValidator : AbstractValidator<SupplierGroupModelRq>
    {
        public SupplierGroupModelValidator()
        {
            RuleFor(p=>p.Name).NotEmpty();
        }
    }
}
