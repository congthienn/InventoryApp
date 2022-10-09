﻿using InventoryApp.Data.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("Warehouses")]
    public class Warehouses : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CodeName { get; set; }
        public Guid BranchId { get; set; }
        public Branches? Branch { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
    }
}
