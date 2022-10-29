using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ShowMaterialAttributeValue
    {
        public MaterialAttributeModel? MaterialAttribute { get; set; }
        public string Value { get; set; }
    }
}
