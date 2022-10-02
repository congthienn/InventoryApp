using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class DistrictDTO : PlaceDTO
    {
        public JArray Wards { get; set; }
    }
}
