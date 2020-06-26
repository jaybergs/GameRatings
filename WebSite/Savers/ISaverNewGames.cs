using Data.Models;
using WebSite.Models;
namespace WebSite.Savers
{
    public interface ISaverNewGames
    {
        void Save(NewGameViewModel game, GameRatingsDbContext db);
        void FromCsv(string path, char seperator);
    }
}
