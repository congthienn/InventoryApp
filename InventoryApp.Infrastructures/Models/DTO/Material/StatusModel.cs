using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class StatusModel
    {
        public bool Status { get; set; }
    }
    public class StatusModelValidator : AbstractValidator<StatusModel>
    {
        public StatusModelValidator()
        {
            RuleFor(p=>p.Status).NotEmpty();
        }
    }
}
