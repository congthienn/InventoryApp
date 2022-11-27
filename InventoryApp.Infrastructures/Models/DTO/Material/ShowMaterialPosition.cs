using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ShowMaterialPosition
    {
        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        public Guid ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
        public int MaterialQuantity { get; set; }
        public int QuantityInStock { get; set; }
        public string Position { get; set; }
    }
}
