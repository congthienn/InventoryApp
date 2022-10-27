using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class ShowMaterialPicture
    {
        public string PictureURL { get; set; }
        public Guid MaterialId { get; set; }
    }
}
