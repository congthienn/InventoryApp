﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("UserTokens")]
    public class UserTokens : IdentityUserToken<Guid>
    {
        public override Guid UserId { get => base.UserId; set => base.UserId = value; }
        public Users? User { get; set; }
    }
}
