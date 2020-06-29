using Data.Models;
using System.Linq;
using WebSite.Models;

namespace WebSite.Savers
{
    public class SaverNewRecords : ISaverNewRecords
    {
        public void Save(GamesViewModel gamesModel, GameRatingsDbContext db)
        {
            foreach (string dev in gamesModel.Developers.Split(';'))
            {
                if (!db.Developer.Any(d => d.Name == dev))
                {
                    db.Developer.Add(new Developers(dev));
                }
            }

            foreach (string gen in gamesModel.Genres.Split(';'))
            {
                if (!db.Genre.Any(g => g.Name == gen))
                {
                    db.Genre.Add(new Genres(gen));
                }
            }

            foreach (string platform in gamesModel.Platforms.Split(';'))
            {
                if (!db.Platform.Any(p => p.Name == platform))
                {
                    db.Platform.Add(new Platforms(platform));
                }
            }

            if (!db.Publisher.Any(p => p.Name == gamesModel.Publisher))
            {
                db.Publisher.Add(new Publishers(gamesModel.Publisher));
            }
        }
    }
}