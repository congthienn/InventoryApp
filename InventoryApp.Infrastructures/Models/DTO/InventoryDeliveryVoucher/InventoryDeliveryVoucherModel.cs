using FluentValidation;
using InventoryApp.Infrastructures.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO 
{ 
    public class InventoryDeliveryVoucherModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; private set; }
        public int Status { get; private set; } = (int)INVENTORY_DELIVERY_VOUCHER_STATUS.WaitingForApproval;
        public int Purpose { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid BranchId { get; set; }
        public Guid UserRequestId { get; set; }
        public Guid? UserApproveId { get; set; }
        public DateTime? GoodsIssueDate { get; set; }
        public int? OrderId { get; set; }
        public List<InventoryDeliveryVoucherDetailModel> Details { get; set; }
    }
    public class InventoryDeliveryVoucherModelValidator : AbstractValidator<InventoryDeliveryVoucherModel>
    {
        public InventoryDeliveryVoucherModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.WarehouseId).NotEmpty();
            RuleFor(p => p.BranchId).NotEmpty();
            RuleFor(p => p.UserRequestId).NotEmpty();
        }
    }
}
