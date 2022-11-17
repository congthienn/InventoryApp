using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class WarehouseModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; private set; }
        public Guid BranchId { get; set; }
        public BranchModelRq Branch { get; set; }
        public bool Status { get; set; } = true;
        public int MaximumCapacity { get; set; }
        public int Blank { get; private set; }
        public string? Remarks { get; set; }
    }
    public class WarehouseModelValidator : AbstractValidator<WarehouseModel>
    {
        public WarehouseModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.BranchId).NotEmpty();
            RuleFor(p => p.MaximumCapacity).NotEmpty();
        }
    }
}
