using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.HTTP
{
    public class Client : IClient<Games>
    {
        private readonly HttpClient client;

        public Client(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Games> GetAsync(string name)
        {
            using (HttpResponseMessage response = await client.GetAsync("api/games/" + name))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Games game = JsonConvert.DeserializeObject<Games>(json);
                    return game;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<string>> GetDevelopers()
        {
            List<string> devList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync("api/list/developers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    devList = JsonConvert.DeserializeObject<List<string>>(json);
                    return devList;
                }
                else
                {
                    devList.Add("");
                    return devList;
                }
            }
        }

        public async Task<List<string>> GetGenres()
        {
            List<string> genreList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync("api/list/genres"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    genreList = JsonConvert.DeserializeObject<List<string>>(json);
                    return genreList;
                }
                else
                {
                    genreList.Add("");
                    return genreList;
                }
            }
        }

        public async Task<List<string>> GetPublishers()
        {
            List<string> publisherList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync("api/list/publihsers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    publisherList = JsonConvert.DeserializeObject<List<string>>(json);
                    return publisherList;
                }
                else
                {
                    publisherList.Add("");
                    return publisherList;
                }
            }
        }

        public async Task<List<string>> GetPlatforms()
        {
            List<string> platformList = new List<string>();
            using (HttpResponseMessage response = await client.GetAsync("api/list/platforms"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    platformList = JsonConvert.DeserializeObject<List<string>>(json);
                    return platformList;
                }
                else
                {
                    platformList.Add("");
                    return platformList;
                }
            }
        }

        public async Task<string> PutAsync(GamesViewModel gamesModel)
        {
            var content = new StringContent(JsonConvert.SerializeObject(gamesModel), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PutAsync("api/games", content))
            {
                string result = response.Content.ReadAsStringAsync().ToString();

                return result;
            }
        }

        public async Task<string> PostAsync(GamesViewModel gamesModel)
        {
            var content = new StringContent(JsonConvert.SerializeObject(gamesModel), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync("api/games", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().ToString();
                    return result;
                }
                else
                {
                    throw new Exception("Request not successful. Statuscode: " + response.StatusCode.ToString());
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (HttpResponseMessage response = await client.DeleteAsync("api/games/" + id))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Request not successful.Statuscode: " + response.StatusCode);
                }
            }
        }
    }
}