using Newtonsoft.Json.Linq;

namespace InventoryApp.Infrastructures.Helper
{
    public static class HttpClientHelper
    {
        public static async Task<JArray> CallAPI(string urlAPI)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(urlAPI);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<JArray>();

            return null;
        }
    }
}