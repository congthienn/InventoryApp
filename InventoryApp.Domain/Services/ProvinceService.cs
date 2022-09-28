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
    public class ProvinceService : IProvinceService
    {
        public Task<ApiResult<Provinces>> AddProvince(Provinces provinces)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Districts>> GetDitrictsByProvinceId(int code)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Provinces>> GetProvinces()
        {
            throw new NotImplementedException();
        }
    }
}
