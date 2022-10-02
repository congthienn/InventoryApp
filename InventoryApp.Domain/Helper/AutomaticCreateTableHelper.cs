using InventoryApp.Common;
using InventoryApp.Infrastructures.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Services;
using Newtonsoft.Json.Linq;

namespace InventoryApp.Domain.Helper
{
    public class AutomaticCreateTableHelper
    {
        private IProvinceService _provinceService;
        public AutomaticCreateTableHelper()
        {
            _provinceService = new ProvinceService();
        }
        private async void CreateProvinceTable()
        {
            if (ProvinceDataExitsInDatabase().Result)
                return;
            string url = GetStringAppsetting.GetProvincialAPI();
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
            var provinceData = await _provinceService.GetProvinces();
            if (provinceData.Count() > 0)
                return true;
            return false;
        }
        public static void Run()
        {
            AutomaticCreateTableHelper createTableHelper = new AutomaticCreateTableHelper();
            createTableHelper.CreateProvinceTable();
        }
    }
}