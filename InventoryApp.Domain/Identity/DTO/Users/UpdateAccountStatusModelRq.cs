using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.DTO.Users
{
    public class UpdateAccountStatusModelRq
    {
        public Guid UserId { get; set; }
        public bool Status { get; set; }
    }
}
