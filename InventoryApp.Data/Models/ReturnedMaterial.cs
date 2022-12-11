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
    [Table("ReturnedMaterial")]
    [Index(nameof(OrderId), IsUnique = true)]
    public class ReturnedMaterial : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get;set; }
        public string Reason { get; set; }
        public bool Formula { get; set; }
        public List<ReturnedMaterialDetail> Detail { get; set; }
    }
}
