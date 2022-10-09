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
        public string Name { get; set; }
        public string Code { get; set; }
        public int StatusId { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouses? Warehouse { get; set; }
        public Guid BranchRequestId { get; set; }
        public Branches? BranchRequest { get; set; }
        public Guid EmployeeRequestId { get; set; }
        public Employees? EmployeeRequest { get; set; }
        public Guid EmployeeDeliveryId { get; set; }
        public Employees? EmployeeDelivery { get; set; }
    }
}
