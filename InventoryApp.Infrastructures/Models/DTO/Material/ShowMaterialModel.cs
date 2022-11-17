using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ShowMaterialModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Code { get; set; }
        public int SalePrice { get; set; }
        public int CostPrice { get; set; }
        public string BaseMaterialUnit { get; set; }
        public Guid CategoryMaterialId { get; set; }
        public MaterialCategoryModelRq CategoryMaterial { get; set; }
        public Guid TrademarkId { get; set; }
        public TrademarkModelRq Trademark { get; set; }
        public int MinimumInventory { get; set; }
        public int MaximumInventory { get; set; }
        public double Weight { get; set; }
        public string DetailedDescription { get; set; }
        public List<ShowMaterialPicture>? Pictures { get; set; }
        public bool StopBusiness { get; set; }
    }
}
