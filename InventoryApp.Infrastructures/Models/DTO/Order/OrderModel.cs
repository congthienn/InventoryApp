using FluentValidation;
using InventoryApp.Infrastructures.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class OrderModel
    {

        public int Id { get; private set; }
        public string Code { get; private set; }
        public int Status { get; set; } = (int)ORDER_STATUS.Processing;
        public Guid CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid BranchId { get; set; }
        public BranchModelRq Branch { get; set; }
        public List<OrderDetailModel> OrderDetail { get; set; }
        public int PriceTotal { get; private set; }
        public int Prepayment { get; set; }
        public bool Paid { get; set; }
    }
    public class OrderModelValidator : AbstractValidator<OrderModel>
    {
        public OrderModelValidator()
        {
            RuleFor(p=>p.CustomerId).NotEmpty();
            RuleFor(p=>p.BranchId).NotEmpty();
            RuleFor(p => p.OrderDate).NotEmpty();
        }
    }
}
