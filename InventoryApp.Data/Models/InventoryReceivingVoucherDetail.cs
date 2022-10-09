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
    [Table("InventoryReceivingVoucherDetail")]
    public class InventoryReceivingVoucherDetail : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InventoryReceivingVoucherId { get; set; }
        public InventoryReceivingVoucher? InventoryReceivingVoucher { get; set; }
        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        public Guid MaterialUnitId { get; set; }
        public MaterialUnits? MaterialUnit { get; set; }
        public int QuatityRequest { get; set; }
        public int QuatityReceiving { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }
}
