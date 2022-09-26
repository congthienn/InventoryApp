using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("WarehouseLocation")]
    public class WarehouseLocation
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouses? Warehouse { get; set; }
        public Guid WarehouseAreaId { get; set; }
        public WarehouseArea? WarehouseArea { get; set; }
        public Guid WarehouseLineId { get; set; }
        public WarehouseLine? WarehouseLine { get; set; }
        public Guid WarehouseShelvesId { get; set; }
        public WarehouseShelves? WarehouseShelves { get; set; }
        public Guid WarehouseRackId { get; set; }
        public WarehouseRack? WarehouseRack { get; set; }
        public Guid WarehousePositionId { get; set; }
        public WarehousePosition? WarehousePosition { get; set; }
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
