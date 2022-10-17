using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace InventoryApp.Application.Controllers
{
    public class ProvinceController : BaseController
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Provinces> GetProvinces()
        {
            return _provinceService.GetProvinces();
        }

        [Route("districts/{provinceId}")]
        [HttpGet()]
        public IEnumerable<Districts> GetDistricts(int provinceId)
        {
            return _provinceService.GetDitrictsByProvinceId(provinceId);
        }

        [Route("wards/{districtId}")]
        [HttpGet]
        public IEnumerable<Wards> GetWards(int districtId)
        {
            return _provinceService.GeWardsByDistrictId(districtId);
        }

        [Route("{provinceId}")]
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