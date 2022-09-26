using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("InventoryMaterial")]
    public class InventoryMaterial
    {
        [Key]
        public Guid Id { get; set; }
        public int QuantityBalance { get; set; }
        public int ExistingBalance { get; set; }
        public int PeriodInput { get; set; }
        public int PeriodOutput { get; set; }
        public int BookingQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime LastBalanceDate { get; set; }
        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        public Guid WarehouseLocationId { get; set; }
        public WarehouseLocation? WarehouseLocation { get; set; }
        public Guid InventoryMaterialPeriodId { get; set; }
        public InventoryMaterialPeriod? InventoryMaterialPeriod { get; set; }
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
