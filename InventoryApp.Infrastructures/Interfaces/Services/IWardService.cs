using InventoryApp.Common.ApiActionResult;
using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IWardService
    {
        Task<ApiResult<Wards>> AddWard(Wards wards);
    }
}