using InventoryApp.Data.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("Roles")]
    [Index(nameof(Roles.Name), IsUnique = true)]
    public class Roles : IdentityRole<Guid>
    {
        public override Guid Id { get; set; }
        public DateTime CreatedDate { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        [ForeignKey("CreatedByUserId")]
        public Users? CreatedByUser { get; set; }
        public DateTime UpdatedDate { get; private set; }
        public Guid UpdatedByUserId { get; private set; }
        [ForeignKey("UpdatedByUserId")]
        public Users? UpdatedByUser { get; set; }

        public void CreateBy(UserIdentity issuer)
        {
            CreatedDate = GetTime();
            CreatedByUserId = issuer.Id;
        }
        public void UpdateBy(UserIdentity issuer)
        {
            UpdatedDate = GetTime();
            UpdatedByUserId = issuer.Id;
        }
        private DateTime GetTime()
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cstZone);
        }
    }
}