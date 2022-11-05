using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{ 
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public Guid MaterialId { get; set; }
        public int QuantityRequest { get; set; }
    }
    public class OrderDetailModelValidator : AbstractValidator<OrderDetailModel>
    {
        public OrderDetailModelValidator()
        {
            RuleFor(p => p.MaterialId).NotEmpty();
            RuleFor(p => p.QuantityRequest).NotEmpty();
        }
    }
}
