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
    [Table("Shipment")]
    [Index(nameof(Code), IsUnique = true)]
    public class Shipment : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid BranchId { get; set; }
        public Branches? Branch { get; set; }
    }
}
