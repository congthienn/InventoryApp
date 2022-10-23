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
    [Table("SupplierGroup")]
    [Index(nameof(Name), IsUnique = true)]
    public class SupplierGroup : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Unicode(true)]
        public string Name { get; set; }
        [Unicode(true)]
        public string Description { get; set; }

        public List<Supplier>? Suppliers { get; set;}
    }
}
