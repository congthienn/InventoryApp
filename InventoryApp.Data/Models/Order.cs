﻿using InventoryApp.Data.Helper;
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
    [Table("Order")]
    [Index(nameof(Code), IsUnique = true)]
    public class Order : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid BranchId { get; set; }
        public Branches? Branch { get; set; }
        public List<OrderDetail>? OrderDetail { get; set; }
        public int PriceTotal { get; set; }
        public int Prepayment { get; set; }
        public bool Paid { get; set; }
        public string DeliveryAddress { get; set; }
        public Guid? DeliveryCompanyId { get; set; }
        public DeliveryCompany DeliveryCompany { get; set; }
    }
}
