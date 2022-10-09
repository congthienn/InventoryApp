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
    [Index(nameof(CodeName), IsUnique = true)]
    public class MaterialAttribute : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        [MaxLength(10)]
        public string DataType { get; set; }
    }
}