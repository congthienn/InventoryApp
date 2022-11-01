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
    [Table("WarehouseLine")]
    [Index(nameof(Name), nameof(WarehouseAreaId), IsUnique = true)]
    [Index(nameof(Code), nameof(WarehouseAreaId), IsUnique = true)]
    public class WarehouseLine : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Unicode(true)]
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid WarehouseAreaId { get; set; }
        public WarehouseArea? WarehouseArea { get; set; }
        public List<WarehouseShelves>? WarehouseShelves { get; set; }
    }
}
