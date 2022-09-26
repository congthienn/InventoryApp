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
        public override Guid Id { get; set; }
        [Unicode(true)]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
    }
}