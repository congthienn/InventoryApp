using InventoryApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.Models
{
    public class SignInModel
    {
        public SignInModel()
        {
        }
        public SignInModel(SignInResult originResult)
        {
            this.Succeeded = originResult.Succeeded;
            this.IsLockedOut = originResult.IsLockedOut;
            this.RequiresTwoFactor = originResult.RequiresTwoFactor;
        }
        public bool Succeeded { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsNotAllowed { get; set; }
        public bool RequiresTwoFactor { get; set; }
        public IEnumerable<string>? Roles { get; set; }
        public Users UserIdentity { get; set; }
        public string AvatarURL { set; get; }
    }
}
