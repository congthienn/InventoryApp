﻿using InventoryApp.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.IServices
{
    public interface IAuthService
    {
        Task<SignInModel> SignInAsync(string email, string password, bool lockoutOnFailure);
    }
}
