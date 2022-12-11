using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class SupplierOrderModel
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public int Status { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid SupplierId { get; set; }
        public SupplierModelRq Supplier { get; private set; } 
        public Guid BranchRequestId { get; set; }
        public BranchModelRq BranchRequest { get;  private set; }
        public List<SupplierOrderDetailModel> SupplierOrderDetail { get; set; }
        public int PriceTotal { get; set; }
        public string EmployeeName { get; set; }
        public Guid CreatedByUserId { get; private set; }
    }
    public class SupplierOrderModelValidator : AbstractValidator<SupplierOrderModel>
    {
        public SupplierOrderModelValidator()
        {
            RuleFor(p => p.SupplierId).NotEmpty();
            RuleFor(p=>p.BranchRequestId).NotEmpty();
            RuleFor(p => p.OrderDate).NotEmpty();
        }
    }
}
