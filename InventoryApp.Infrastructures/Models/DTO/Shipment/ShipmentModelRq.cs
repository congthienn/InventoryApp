using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ShipmentModelRq
    {
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid BranchId { get; set; }
    }
    public class ShipmentModelValidator : AbstractValidator<ShipmentModelRq>
    {
        public ShipmentModelValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.ExpirationDate).NotEmpty();
            RuleFor(p => p.BranchId).NotEmpty();
        }
    }
}
