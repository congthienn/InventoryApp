using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO.InventoryReceivingVoucher
{
    public class MaterialPositionModel
    {
        public Guid MaterialId { get; set; }

        public Guid WarehouseShelveId { get; set; }
    }
}
