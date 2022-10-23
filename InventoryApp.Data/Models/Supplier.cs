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
    [Table("Supplier")]
    [Index(nameof(Supplier.Email), IsUnique = true)]
    [Index(nameof(Supplier.PhoneNumber), IsUnique = true)]
    [Index(nameof(Supplier.Code), IsUnique = true)]
    [Index(nameof(Supplier.TaxCode), IsUnique = true)]
    [Index(nameof(Supplier.Fax), IsUnique = true)]
    [Index(nameof(Supplier.Code), IsUnique = true)]
    public class Supplier : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Unicode(true)]
        public string SupplierName { get; set; }
        public string Code { get; set; }
        public string CodeName { get; set; }
        [Unicode(true)]
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public Provinces? Province { get; set; }
        public int DistrictId { get; set; }
        public Districts? District { get; set; }
        public int WardId { get; set; }
        public Wards? Ward { get; set; }
        public string Email { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(10)]
        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string? LogoURL { get; set; }
        public string? WebsiteURL { get; set; }
        public string? FacebookName { get; set; }
        public bool Status { get; set; }
        public Guid SupplierGroupId { get; set; }
        public SupplierGroup? SupplierGroup { get; set; }
    }
}
