using Bowling.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Infrastructure
{
    public class ApiService: IApiService
    {
        public async Task<Response> FetchData<Response>(string url)
        {
            string jsonString = string.Empty;

            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url);
            }
            
            return JsonConvert.DeserializeObject<Response>(jsonString);
        }

        public async Task<Response> PostData<Payload, Response>(Payload payload, string url)
        {
            var jsonObject = JsonConvert.SerializeObject(payload);

            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse;

            using (var client = new HttpClient())
            {
                httpResponse = await client.PostAsync(url, content);
            }

            var jsonString = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response>(jsonString);
        }
    }
}
