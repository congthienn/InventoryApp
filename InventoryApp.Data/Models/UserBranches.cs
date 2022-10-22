using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{

    [Table("UserBranches")]
    public class UserBranches
    {
        public Guid UserId { get; set; }
        public Users? User { get; set; }
        public Guid BranchId { get; set; }
        public Branches Branch { get; set; }
    }
}
