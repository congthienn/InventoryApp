using InventoryApp.Data.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("SupplierOrder")]
    [Index(nameof(Code), IsUnique = true)]
    public class SupplierOrder : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public Guid BranchRequestId { get; set; }
        public Branches? BranchRequest { get; set; }
    }
}
