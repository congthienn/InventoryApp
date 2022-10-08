using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [Route("province")]
        [HttpGet]
        public async Task<IEnumerable<Provinces>> GetProvinces()
        {
            return await _provinceService.GetProvinces();
        }

        [Route("district/province/{provinceId}")]
        [HttpGet()]
        public async Task<IEnumerable<Districts>> GetDistricts(int provinceId)
        {
            return await _provinceService.GetDitrictsByProvinceId(provinceId);
        }

        [Route("ward/{districtId}")]
        [HttpGet]
        public async Task<IEnumerable<Wards>> GetWards(int districtId)
        {
            return await _provinceService.GeWardsByDistrictId(districtId);
        }

        [Route("province/{provinceId}")]
        [HttpGet]
        public IQueryable GetProvinces(int provinceId)
        {
            return _provinceService.GetProvinceById(provinceId);
        }

        [Route("district/{districtId}")]
        [HttpGet]
        public IQueryable GetDistrictById(int districtId)
        {
            return _provinceService.GetDistrictById(districtId);
        }

    }
}