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
    [Table("InventoryMaterialPeriod")]
    [Index(nameof(Code), IsUnique = true)]
    public class InventoryMaterialPeriod : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get;set; }
        public DateTime ConfirmedDate { get; set; }
        public Guid ConfirmedByEmployeesId { get; set; }
        public Employees? ConfirmedByEmployees { get; set; }
        public bool Locked { get; set; }
    }
}
