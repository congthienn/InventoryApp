using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class CustomerGroupModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountMoney { get; set; }
        public string? Note { get; set; }
    }

    public class CustomerGroupModelValidator : AbstractValidator<CustomerGroupModel>
    {
        public CustomerGroupModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
