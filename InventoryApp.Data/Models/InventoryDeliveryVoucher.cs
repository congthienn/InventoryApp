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
        public int StatusId { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouses? Warehouse { get; set; }
        public Guid BranchRequestId { get; set; }
        public Branches? BranchRequest { get; set; }
        public Guid UserRequestId { get; set; }
        public Users? UserRequest { get; set; }
        public Guid UserDeliveryId { get; set; }
        public Users? UserDelivery { get; set; }
        public Guid UserApproveId { get; set; }
        public Users? UserApprove { get; set; }
    }
}
