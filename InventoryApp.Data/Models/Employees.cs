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
    [Table("Employees")]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Index(nameof(IdentityCardNumber), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Employees
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CodeName { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public Provinces? Province { get; set; }
        public int DistrictId { get; set; }
        public Districts? District { get; set; }
        public int WardId { get; set; }
        public Wards? Ward { get; set; }
        public string? Email { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int BirthPlaceId { get; set; }
        public Provinces? BirthPlace { get; set; }
        public string IdentityCardNumber { get; set; }
        public DateTime IdentityCardDate { get; set; }
        public int IdentityCardPlaceId { get; set; }
        public Provinces? IdentityCardPlace { get; set; }
        public Guid UserId { get; set; }
        public Users? User { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public Users? CreatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
        [ForeignKey("UpdatedByUserId")]
        public Users? UpdatedByUser { get; set; }
        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
