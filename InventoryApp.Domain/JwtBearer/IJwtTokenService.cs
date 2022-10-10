using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.JwtBearer
{
    public interface IJwtTokenService
    {
        JwtToken GenerateJwtToken(Users user, IEnumerable<string> roles = null);
    }
}
