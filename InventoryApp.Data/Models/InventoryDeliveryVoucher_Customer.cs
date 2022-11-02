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
    [Table("InventoryDeliveryVoucher_Customer")]
    [Index(nameof(CustomerId), nameof(InventoryDeliveryVoucherId), IsUnique = true)]
    public class InventoryDeliveryVoucher_Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public Guid InventoryDeliveryVoucherId { get; set; }
        public InventoryDeliveryVoucher? InventoryDeliveryVoucher { get; set; }
    }
}
