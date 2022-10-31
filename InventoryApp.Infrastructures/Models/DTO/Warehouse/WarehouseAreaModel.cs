using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class WarehouseAreaModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; private set; }
        public Guid WarehouseId { get; set; }
    }
    public class WarehouseAreaValidator : AbstractValidator<WarehouseAreaModel>
    {
        public WarehouseAreaValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.WarehouseId).NotEmpty();
        }
    }
}
