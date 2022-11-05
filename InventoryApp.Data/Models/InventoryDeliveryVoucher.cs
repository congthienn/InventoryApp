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
    [Table("InventoryDeliveryVoucher")]
    public class InventoryDeliveryVoucher : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public int Purpose { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouses? Warehouse { get; set; }
        public Guid BranchRequestId { get; set; }
        public Branches? BranchRequest { get; set; }
        public Guid UserRequestId { get; set; }
        public Users? UserRequest { get; set; }
        public Guid UserApproveId { get; set; }
        public Users? UserApprove { get; set; }
        public DateTime? GoodsIssueDate { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
