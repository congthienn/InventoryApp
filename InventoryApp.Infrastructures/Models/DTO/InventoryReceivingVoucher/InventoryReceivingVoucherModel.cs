using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class InventoryReceivingVoucherModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; private set; }
        public Guid WarehouseId { get; set; }
        public WarehouseModel Warehouse { get; private set; }
        public Guid BranchRequestId { get; set; }
        public BranchModelRq BranchRequest { get;  private set; }
        public Guid UserReceiveId { get; set; }
        public string UserReceiveName { get; set; }
        public DateTime GoodsImportDate { get; set; }
        public int? SupplierOrderId { get; set; }
        public SupplierOrderModel SupplierOrder { get; private set; }
        public SupplierModelRq Supplier { get; set; }
        public List<InventoryReceivingVoucherDetailModel> Detail { get; set; }
        public string EmployeeName { get; set; }
        public Guid CreatedByUserId { get; private set; }
    }
    public class InventoryReceivingVoucherModelValidator : AbstractValidator<InventoryReceivingVoucherModel>
    {
        public InventoryReceivingVoucherModelValidator()
        {
            RuleFor(p => p.WarehouseId).NotEmpty();
            RuleFor(p => p.BranchRequestId).NotEmpty();
            RuleFor(p => p.UserReceiveId).NotEmpty();
            RuleFor(p => p.SupplierOrderId).NotEmpty();
        }
    }
}
