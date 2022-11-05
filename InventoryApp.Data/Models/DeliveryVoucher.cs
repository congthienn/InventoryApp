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
    [Table("DeliveryVoucher")]
    [Index(nameof(CustomerId), nameof(InventoryDeliveryVoucherId), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public class DeliveryVoucher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid InventoryDeliveryVoucherId { get; set; }
        public InventoryDeliveryVoucher? InventoryDeliveryVoucher { get; set; }
        public double MaterialPrice { get; set; }
        public double Amount { get; set; }
        public Users? DeliveryUser { get; set; }
        public Guid DeliveryUserId { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
