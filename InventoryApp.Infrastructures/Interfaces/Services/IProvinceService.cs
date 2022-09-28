using InventoryApp.Common.ApiActionResult;
using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IProvinceService
    {
        Task<ApiResult<Provinces>> AddProvince(Provinces provinces);
        Task<IEnumerable<Provinces>> GetProvinces();
        Task<IEnumerable<Districts>> GetDitrictsByProvinceId(int code);
    }
}