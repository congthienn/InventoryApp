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
        public int SalePrice { get; set; }
        public int CostPrice { get; set; }
        public string BaseMaterialUnit { get; set; }
        public Guid CategoryMaterialId { get; set; }
        public MaterialsCategory? CategoryMaterial { get; set; }
        public Guid TrademarkId { get; set; }
        public Trademark Trademark { get; set; }
        public int MinimumInventory { get; set; }
        public int MaximumInventory { get; set; }
        public string Weight { get; set; }
        public string DetailedDescription { get; set; }
    }
}
