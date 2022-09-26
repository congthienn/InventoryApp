using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("RoleClaims")]
    public class RoleClaims : IdentityRoleClaim<Guid>
    {
        public override Guid RoleId { get => base.RoleId; set => base.RoleId = value; }
        public Roles? Role { get;set; }
    }
}
