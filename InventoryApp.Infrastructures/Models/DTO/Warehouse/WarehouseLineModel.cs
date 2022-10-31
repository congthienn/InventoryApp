using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class WarehouseLineModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; private set; }
        public Guid WarehouseAreaId { get; set; }
    }

    public class WarehouseLineModelValidator : AbstractValidator<WarehouseLineModel>
    {
        public WarehouseLineModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.WarehouseAreaId).NotEmpty();
        }
    }
}
