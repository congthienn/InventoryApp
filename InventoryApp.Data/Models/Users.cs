using InventoryApp.Data.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Data.Models
{
    [Table("Users")]
    [Index(nameof(Users.Email),IsUnique = true)]
    [Index(nameof(Users.PhoneNumber),IsUnique = true)]
    public class Users : IdentityUser<Guid>
    {
        public override Guid Id { get; set; } = Guid.NewGuid();
        [Unicode(true)]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public DateTime CreatedDate { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public Guid UpdatedByUserId { get; private set; }
        public bool Status { get; set; }

        public string? AvatarURL { get; set; }


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