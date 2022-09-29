using InventoryApp.Common.ApiActionResult;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Services
{
    public class DistrictService : IDistrictService
    {
        public Task<ApiResult<Districts>> AddDistrict(Districts districts)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wards>> GetWardsByDistrictId(int code)
        {
            throw new NotImplementedException();
        }
    }
}
