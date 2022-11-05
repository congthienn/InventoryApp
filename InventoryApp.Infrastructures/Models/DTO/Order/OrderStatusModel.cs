using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class OrderStatusModel
    {
        public int Status { get; set; }
    }
    public class OrderStatusModelValidator : AbstractValidator<OrderStatusModel>
    {
        public OrderStatusModelValidator()
        {
            RuleFor(p=>p.Status).NotEmpty();
        }
    }
}
