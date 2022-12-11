using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ReturnedMaterialModel
    {
        public int Id { get; private set; }
        public int OrderId { get; set; }
        public OrderModel? Order { get; set; }
        public string Reason { get; set; }
        public bool Formula { get; set; } 
        public List<ReturnedMaterialDetailModel> Detail { get; set; }
    }

    public class ReturnedMaterialModelValidator : AbstractValidator<ReturnedMaterialModel>
    {
        public ReturnedMaterialModelValidator()
        {
            RuleFor(p => p.OrderId).NotEmpty();
            RuleFor(p => p.Reason).NotEmpty();
        }
    }
}
