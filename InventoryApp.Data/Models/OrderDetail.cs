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
    [Table("OrderDetail")]
    [Index(nameof(OrderId), nameof(MaterialId), IsUnique = true)]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Guid MaterialId { get; set; }
        public Materials Material { get; set; }
        public int QuantityRequest { get; set; }
        public int MaterialPrice { get; set; }
    }
}
