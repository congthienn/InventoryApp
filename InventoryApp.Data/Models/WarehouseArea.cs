using InventoryApp.Data.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("WarehouseArea")]
    [Index(nameof(Code), nameof(WarehouseId), IsUnique = true)]
    [Index(nameof(Name), nameof(WarehouseId), IsUnique = true)]
    public class WarehouseArea : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Unicode(true)]
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouses Warehouse { get; set; }
    }
}
