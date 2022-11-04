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
    [Table("MaterialShipment")]
    [Index(nameof(MaterialId), nameof(ShipmentId), IsUnique = true)]
    public class MaterialShipment : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        public Guid ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
        public int MaterialQuantity { get; set; }
    }
}
