using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class InventoryDeliveryVoucherDetailModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ShipmentId { get; set; }
        public int QuantityRequest { get; set; }
        public int QuantityDelivery { get; set; }
    }
    public class InventoryDeliveryVoucherDetailModelValidator : AbstractValidator<InventoryDeliveryVoucherDetailModel>
    {
        public InventoryDeliveryVoucherDetailModelValidator()
        {
            RuleFor(p => p.ShipmentId).NotEmpty();
            RuleFor(p => p.QuantityRequest).NotEmpty();
            RuleFor(p => p.QuantityDelivery).NotEmpty();
        }
    }
}
