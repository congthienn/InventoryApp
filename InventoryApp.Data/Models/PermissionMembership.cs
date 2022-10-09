using InventoryApp.Data.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("PermissionMembership")]
    public class PermissionMembership : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PermissionGroupId { get; set; }
        public PermissionGroup? PermissionGroup { get; set; }
        public Guid UserId { get; set; }
        public Users? User { get; set; }
    }
}
