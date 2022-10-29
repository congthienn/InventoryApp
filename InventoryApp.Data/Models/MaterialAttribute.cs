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
    [Table("MaterialAttribute")]
    [Index(nameof(Name), nameof(MaterialsCategoryId), IsUnique = true)]
    public class MaterialAttribute : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialAttributeId { get; set; }
        [MaxLength(50), Unicode]
        public string Name { get; set; }
        public Guid MaterialsCategoryId { get; set; }
        public MaterialsCategory? MaterialsCategory { get; set; }
    }
}