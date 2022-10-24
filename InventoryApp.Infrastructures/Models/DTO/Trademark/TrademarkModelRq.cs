using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class TrademarkModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
    public class TrademarkModelValidator : AbstractValidator<TrademarkModelRq>
    {
        public TrademarkModelValidator()
        {
            RuleFor(p=>p.Name).NotEmpty();
        }
    }
}
