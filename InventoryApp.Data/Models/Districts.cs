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
    [Table("Districts")]
    public class Districts
    {
        [Key]
        public int Code { get; set; }
        [Unicode(true)]
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string DivisionType { get; set; }
        public int ProvinceId { get; set; }
        public Provinces? Province { get; set; }
        public List<Wards> Ward { get; set; }
    }
}