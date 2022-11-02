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
    [Table("InventoryDeliveryVoucherDetail")]
    [Index(nameof(InventoryDeliveryVoucherId), nameof(ShipmentId), IsUnique =true)]
    public class InventoryDeliveryVoucherDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InventoryDeliveryVoucherId { get; set; }
        public InventoryDeliveryVoucher? InventoryDeliveryVoucher { get; set; }
        public Guid ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
        public int QuatityRequest { get; set; }
        public int QuatityDelivery { get; set; }
        public double MaterialPrice { get; set; }
        public double Amount { get; set; }
    }
}
