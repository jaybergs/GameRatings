using WebSite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebSite.HTTP
{
    public class ClientList : IClientList<List<Games>>
    {
        private readonly HttpClient client;

        public ClientList(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<Games>> GetAsync(string search)
        {
            //GET
            using (HttpResponseMessage response = await client.GetAsync("api/list/" + search))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    List<Games> games = JsonConvert.DeserializeObject<List<Games>>(json);
                    return games;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Games>> GetHighestAsync(int count)
        {
            using (HttpResponseMessage response = await client.GetAsync("api/list/highest/" + count))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    List<Games> games = JsonConvert.DeserializeObject<List<Games>>(json);
                    return games;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}