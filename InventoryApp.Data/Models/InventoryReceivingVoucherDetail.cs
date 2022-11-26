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
    [Table("InventoryReceivingVoucherDetail")]
    [Index(nameof(InventoryReceivingVoucherId), nameof(ShipmentId), IsUnique = true)]
    public class InventoryReceivingVoucherDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InventoryReceivingVoucherId { get; set; }
        public InventoryReceivingVoucher? InventoryReceivingVoucher { get; set; }
        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public int QuantityReceiving { get; set; }
        public int DamagedQuantity { get; set; }
        public double Price { get; set; }

    }
}
