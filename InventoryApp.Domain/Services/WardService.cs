using InventoryApp.Common.ApiActionResult;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Services
{
    public class WardService : IWardService
    {
        public Task<ApiResult<Wards>> AddWard(Wards wards)
        {
            throw new NotImplementedException();
        }
    }
}
