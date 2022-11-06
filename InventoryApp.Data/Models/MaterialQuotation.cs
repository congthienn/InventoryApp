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
    [Table("MaterialQuotation")]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(MaterialId), nameof(MinimumQuantity), nameof(MaximumQuantity), IsUnique = true)]
    public class MaterialQuotation : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public Guid MaterialId { get; set; }
        public Materials? Material { get; set; }
        public int CostPrice { get; set; }
        public int MinimumQuantity { get; set; }
        public int MaximumQuantity { get; set; }
    }
}
