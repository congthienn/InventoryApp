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
    [Table("MaterialUnit")]
    [Index(nameof(MaterialUnits.Name), IsUnique = true)]
    public class MaterialUnits : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ExchangeValue { get; set; }
        public Guid MaterialId { get; set; }
        public int Price { get; set; }
        public Materials? Material { get; set; }
        public bool DirectSales { get; set; }
    }
}