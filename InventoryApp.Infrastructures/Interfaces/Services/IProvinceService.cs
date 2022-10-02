using InventoryApp.Common.ApiActionResult;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IProvinceService
    {
        Task AddProvince(ProvinceDTO provinceDTO, DistrictDTO districtDTO, IEnumerable<WardDTO> wardDTO);
        Task<IEnumerable<Provinces>> GetProvinces();
        Task<IEnumerable<Districts>> GetDitrictsByProvinceId(int provinceId);
        Task<IEnumerable<Wards>> GeWardsByDistrictId(int districtId);
    }
}