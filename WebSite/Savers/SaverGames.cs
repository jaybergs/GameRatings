using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Savers
{
    public class SaverGames : ISaverGames
    {
        public void Save(GamesViewModel gameModel, GameRatingsDbContext db)
        {
            var game = (from gm in db.Games
                        where gm.Name == gameModel.Name
                        select gm).SingleOrDefault();

            game.Rating_ID = (from scr in db.Rating
                              where scr.Score == gameModel.Score
                              select scr.ID).SingleOrDefault();

            game.Publisher_ID = (from pub in db.Publisher
                                 where pub.Name == gameModel.Publisher
                                 select pub.ID).SingleOrDefault();

            List<Developers> newDevs = new List<Developers>();
            foreach (string dev in gameModel.Developers.Split(';'))
            {
                newDevs.Add((from d in db.Developer
                             where d.Name == dev
                             select d).SingleOrDefault());
            }            
            game.Developers.Clear();
            game.Developers = newDevs;

            IList<Genres> newGenres = new List<Genres>();
            foreach (string gen in gameModel.Genres.Split(';'))
            {
                newGenres.Add((from g in db.Genre
                               where g.Name == gen
                               select g).SingleOrDefault());
            }
            game.Genres.Clear();
            game.Genres = newGenres;
            game.Description = gameModel.Description;
            db.SaveChanges();
        }
    }
}
