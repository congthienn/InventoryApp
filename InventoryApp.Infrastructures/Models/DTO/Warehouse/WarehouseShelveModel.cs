using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{ 
    public class WarehouseShelveModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; private set; }
        public Guid WarehouseLineId { get; set; }
    }
    public class WarehouseShelveModelValidator : AbstractValidator<WarehouseShelveModel>
    {
        public WarehouseShelveModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
