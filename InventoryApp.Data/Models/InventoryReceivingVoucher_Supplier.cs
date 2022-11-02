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
    [Table("InventoryReceivingVoucher_Supplier")]
    [Index(nameof(SupplierId), nameof(InventoryReceivingVoucherId), IsUnique = true)]
    public class InventoryReceivingVoucher_Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public Guid InventoryReceivingVoucherId { get; set; }
        public InventoryReceivingVoucher? InventoryReceivingVoucher { get; set; }
    }
}
