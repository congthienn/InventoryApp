using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ProvinceDTO : PlaceDTO
    {
        public JArray Districts { get; set; }
        public int Phone_Code { get; set; }
    }
}