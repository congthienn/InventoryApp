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
    [Table("ReturnedMaterialDetail")]
    [Index(nameof(MaterialId), nameof(ReturnedMaterialId), IsUnique = true)]
    public class ReturnedMaterialDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ReturnedMaterialId { get; set; }
        public ReturnedMaterial ReturnedMaterial { get; set; }
        public Guid MaterialId { get; set; }
        public Materials Material { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
