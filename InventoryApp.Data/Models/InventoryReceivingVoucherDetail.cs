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
    [Index(nameof(InventoryReceivingVoucherId), nameof(MaterialShipmentId), IsUnique = true)]
    public class InventoryReceivingVoucherDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InventoryReceivingVoucherId { get; set; }
        public InventoryReceivingVoucher? InventoryReceivingVoucher { get; set; }
        public int MaterialShipmentId { get; set; }
        public MaterialShipment MaterialShipment { get; set; }
        public int QuantityRequest { get; set; }
        public int QuantityReceiving { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }
}
