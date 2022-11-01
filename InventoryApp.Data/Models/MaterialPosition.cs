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
    [Table("MaterialPosition")]
    [Index(nameof(WarehouseShelveId), IsUnique = true)]
    public class MaterialPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        
        public Guid BrachId { get; set; }
        public Branches? Branch { get; set; }

        public Guid WarehouseShelveId { get; set; }
        public WarehouseShelves? WarehouseShelve { get; set; }
    }
}
