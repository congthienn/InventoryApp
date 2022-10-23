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
    [Table("Branches")]
    [Index(nameof(Branches.Email), IsUnique = true)]
    [Index(nameof(Branches.PhoneNumber), IsUnique = true)]
    [Index(nameof(Branches.Code), IsUnique = true)]
    [Index(nameof(Branches.TaxCode), IsUnique = true)]
    [Index(nameof(Branches.Fax), IsUnique = true)]
    [Index(nameof(Branches.Code), IsUnique = true)]
    public class Branches : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Unicode(true)]
        public string CompanyName { get; set; }
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
        public Guid CompaniesId { get; set; }
        public Company Companies { get; set; }
        public bool BranchMain { get; set; } = false;
        public List<Shipment>? Shipments { get; set; }
    }
}