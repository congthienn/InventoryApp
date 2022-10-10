using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("UserRoles")]
    public class UserRoles : IdentityUserRole<Guid>
    {
        public Users? User { get; set; }
        public Roles? Role { get; set; }
    }
}