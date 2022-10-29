using InventoryApp.Data.Helper;

namespace InventoryApp.Data.Models
{
    public class MaterialAttributeValue : EntityBase
    {
        public int MaterialAttributeId { get; set; }
        public MaterialAttribute? MaterialAttribute { get; set; }
        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        public string Value { get; set; }
    }
}
