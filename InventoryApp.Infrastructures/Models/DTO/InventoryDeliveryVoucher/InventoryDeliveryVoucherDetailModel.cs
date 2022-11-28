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
        public ShipmentModelRq Shipment { get; private set; }
        public Guid ShipmentId { get; set; }
        public MaterialModelRq Material { get; private set; }
        public Guid MaterialId { get; set; }
        public int QuantityDelivery { get; set; }
        public double Price { get; set; }
    }
    public class InventoryDeliveryVoucherDetailModelValidator : AbstractValidator<InventoryDeliveryVoucherDetailModel>
    {
        public InventoryDeliveryVoucherDetailModelValidator()
        {
            RuleFor(p => p.ShipmentId).NotEmpty();
            RuleFor(p => p.MaterialId).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.QuantityDelivery).NotEmpty();
        }
    }
}
