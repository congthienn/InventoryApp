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
    [Table("Materials")]
    public class Materials : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Code { get; set; }
        public string Details { get; set; }
        public Guid MaterialUnitId { get; set; }
        public MaterialUnits? MaterialUnit { get; set; }
        public Guid CategoryMaterialId { get; set; }
        public CategoryMaterials? CategoryMaterial { get; set; }
        public Guid ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int MinimumInventory { get; set; }
        public int MaximumInventory { get; set; }
    }
}
