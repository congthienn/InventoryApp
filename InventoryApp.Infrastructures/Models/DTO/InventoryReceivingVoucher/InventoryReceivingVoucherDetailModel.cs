using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class InventoryReceivingVoucherDetailModel
    {
        public Guid ShipmentId { get; set; }
        public int QuantityReceiving { get; set; }
        public int DamagedQuantity { get; set; }
        public double Price { get; set; }
        public Guid MaterialId { get; set; }
        public Guid WarehouseShelveId { get; set; }
    }
    public class InventoryReceivingVoucherDetailModelValidator : AbstractValidator<InventoryReceivingVoucherDetailModel>
    {
        public InventoryReceivingVoucherDetailModelValidator()
        {
            RuleFor(p => p.ShipmentId).NotEmpty();
            RuleFor(p => p.QuantityReceiving).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.MaterialId).NotEmpty();
            RuleFor(p => p.WarehouseShelveId).NotEmpty();
        }
    }
}
