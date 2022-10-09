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
    [Table("Manufacturer")]
    [Index(nameof(Manufacturer.Email), IsUnique = true)]
    public class Manufacturer : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CodeName { get; set; }
        public string? ForeignName { get; set; }
        public string? ShortName { get; set; }
        public string Email { get; set; }
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        public string? LogoURL { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public Provinces? Province { get; set; }
        public int DistrictId { get; set; }
        public Districts? District { get; set; }
        public int WardId { get; set; }
        public Wards? Ward { get; set; }
        public Guid CompaniesId { get; set; }
        public Companies Companies { get; set; }
    }
}
