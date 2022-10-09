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
    [Table("WarehousePosition")]
    [Index(nameof(Code), IsUnique = true)]
    public class WarehousePosition : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Code { get; set; }
        public Guid WarehouseRackId { get; set; }
        public WarehouseRack WarehouseRack { get; set; }
    }
}
