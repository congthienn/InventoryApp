using InventoryApp.Common;
using InventoryApp.Infrastructures.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Services;
using Newtonsoft.Json.Linq;

namespace InventoryApp.Domain.Helper
{
    public class SeedDataProvinces
    {
        private IProvinceService _provinceService;
        public SeedDataProvinces()
        {
            _provinceService = new ProvinceService();
        }
        private async void SeedData()
        {
            if (ProvinceDataExitsInDatabase().Result)
                return;
            string url = Appsetting.GetProvincialAPI();
            JArray provinceJsonDataList = await HttpClientHelper.CallAPI(url);
            foreach (JToken provinceData in provinceJsonDataList.Children())
            {
                ProvinceDTO province = provinceData.ToObject<ProvinceDTO>();
                IEnumerable<DistrictDTO> districtDataList = province.Districts.ToObject<IEnumerable<DistrictDTO>>();
                foreach (DistrictDTO districtData in districtDataList)
                {
                    IEnumerable<WardDTO> wardDataList = districtData.Wards.ToObject<IEnumerable<WardDTO>>();
                    await _provinceService.AddProvince(province, districtData, wardDataList);
                }
            }
        }
        private async Task<bool> ProvinceDataExitsInDatabase()
        {
            return await _provinceService.RepositoryIsNotEmpty();
        }
        public static void Run()
        {
            SeedDataProvinces seedData = new SeedDataProvinces();
            seedData.SeedData();
        }
    }
}