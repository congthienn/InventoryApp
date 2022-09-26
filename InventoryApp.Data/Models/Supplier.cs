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
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }
        [Unicode(true)]
        public string SupplierName { get; set; }
        public string? AppelationOfForeignTrader { get; set; }
        public string? ForeignName { get; set; }
        public string? ShortName { get; set; }
        [MaxLength(50)]
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
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public Users? CreatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
        [ForeignKey("UpdatedByUserId")]
        public Users? UpdatedByUser { get; set; }
    }
}
