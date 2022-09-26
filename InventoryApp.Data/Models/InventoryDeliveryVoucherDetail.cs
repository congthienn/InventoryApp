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
    public class InventoryDeliveryVoucherDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InventoryDeliveryVoucherId { get; set; }
        public InventoryDeliveryVoucher? InventoryDeliveryVoucher { get; set; }
        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        public Guid MaterialUnitId { get; set; }
        public MaterialUnits? MaterialUnit { get; set; }
        public int QuatityRequest { get; set; }
        public int QuatityDelivery { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public Users? CreatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
        [ForeignKey("UpdatedByUserId")]
        public Users? UpdatedByUser { get; set; }
    }
}
