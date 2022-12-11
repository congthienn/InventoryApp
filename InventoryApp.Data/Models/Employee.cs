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
    [Table("Employee")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Index(nameof(IdentityCard), IsUnique = true)]
    public class Employee : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Unicode(true)]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string IdentityCard { get; set; }
        public string CardImage { get; set; }
        public bool Sex { get; set; }
        public DateTime Birthday { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; } = true;
        [Unicode(true)]
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public Provinces? Province { get; set; }
        public int DistrictId { get; set; }
        public Districts? District { get; set; }
        public int WardId { get; set; }
        public Wards? Ward { get; set; }
        public Guid BranchId { get; set; }
        public Branches? Branch { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; }
    }
}
