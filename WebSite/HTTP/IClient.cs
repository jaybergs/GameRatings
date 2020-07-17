using System.Collections.Generic;
using System.Threading.Tasks;
using WebSite.ViewModels;

namespace WebSite.HTTP
{
    public interface IClient<Toutput>
    {
        public Task<Toutput> GetAsync(string name);

        public Task<string> PutAsync(GamesViewModel gamesModel);

        public Task<string> PostAsync(GamesViewModel gamesModel);

        public Task DeleteAsync(int id);

        public Task<List<string>> GetDevelopers();

        public Task<List<string>> GetGenres();

        public Task<List<string>> GetPublishers();

        public Task<List<string>> GetPlatforms();
    }
}