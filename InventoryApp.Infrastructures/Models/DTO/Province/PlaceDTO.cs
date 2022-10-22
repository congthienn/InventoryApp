using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class PlaceDTO
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Division_Type { get; set; }
    }
}
