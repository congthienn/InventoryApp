using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Services;
using InventoryApp.Infrastructures.Interfaces.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using InventoryApp.Infrastructures.Models.DTO;

namespace InventoryApp.Infrastructures.HttpClients
{
    public static class GetData
    {
        public static async Task<object> CallAPI(string urlAPI)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(urlAPI);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<Object>();

            return null;
        }
    }
    public class CreateProvinceTable
    {
        private IProvinceService _provinceService;
        private IMapper _mapper;
        public CreateProvinceTable()
        {
            _provinceService = new ProvinceService();
        }
        public async void Run()
        {
            var provinceData = await _provinceService.GetProvinces();
            if (provinceData.Count() > 0)
                return;
            string url = "https://provinces.open-api.vn/api/?depth=1";
            JArray dataJson = (JArray)await GetData.CallAPI(url);
            foreach(JToken data in dataJson.Children())
            {
                ProvinceDTO province = data.ToObject<ProvinceDTO>();
                await _provinceService.AddProvince(province);
            }
        }
    }
}