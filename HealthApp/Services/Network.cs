using HealthApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthApp.Backend
{
    public class Network
    {
        private readonly HttpClient client;
        public Network()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("")
            };
        }
        public async Task<bool> VerifyData()
        {
            HttpContent content = new StringContent("");
            HttpResponseMessage message = await client.PostAsync("", content);
            string data = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode || !bool.TryParse(data, out bool verified))
            {
                throw new Exception("Failed to verify data.");
            }
            return verified;
        }
        public async Task<Tiles> DownloadData()
        {
            HttpResponseMessage message = await client.GetAsync("");
            string json = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode)
            {
                throw new Exception("Failed to download data.");
            }
            return JsonConvert.DeserializeObject<Tiles>(json);
        }
    }
}
