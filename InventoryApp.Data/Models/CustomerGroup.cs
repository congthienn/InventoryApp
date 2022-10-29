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
    [Table("CustomerGroup")]
    [Index(nameof(Name), IsUnique = true)]
    public class CustomerGroup : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountMoney { get; set; }
        public string? Note { get; set; }
    }
}
