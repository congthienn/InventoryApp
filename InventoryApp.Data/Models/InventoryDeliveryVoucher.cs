using InventoryApp.Data.Helper;
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
        public string Code { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouses? Warehouse { get; set; }
        public Guid BranchId { get; set; }
        public Branches? Branch { get; set; }
        public DateTime? GoodsIssueDate { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public Guid UserDeliveryId { get; set; }
        public Users? UserDelivery { get; set; }
        public List<InventoryDeliveryVoucherDetail> Details { get; set; }  
    }
}
