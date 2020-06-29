using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Savers
{
    public class SaverNewGames : ISaverNewGames
    {
        public void Save(GamesViewModel game, GameRatingsDbContext db)
        {
            foreach (string dev in game.Developers.Split(';'))
            {
                if (!db.Developer.Any(d => d.Name.ToUpper() == dev.ToUpper()))
                {
                    db.Developer.Add(new Developers(dev));
                }
            }

            foreach (string gen in game.Genres.Split(';'))
            {
                if (!db.Genre.Any(g => g.Name.ToUpper() == gen.ToUpper()))
                {
                    db.Genre.Add(new Genres(gen));
                }
            }

            if (!db.Publisher.Any(p => p.Name.ToUpper() == game.Publisher.ToUpper()))
            {
                db.Publisher.Add(new Publishers(game.Publisher));
            }

            if (!db.Links.Any(l => l.Link.ToUpper() == game.Link.ToUpper()))
            {
                db.Links.Add(new Links(game.Link));
            }

            db.SaveChanges();

            List<Developers> devList = new List<Developers>();
            foreach (string dev in game.Developers.Split(';'))
            {
                devList.Add((from d in db.Developer
                             where d.Name == dev
                             select d).SingleOrDefault());
            }

            List<Genres> genList = new List<Genres>();
            foreach (string gen in game.Genres.Split(';'))
            {
                genList.Add((from g in db.Genre
                             where g.Name == gen
                             select g).SingleOrDefault());
            }

            List<Platforms> platList = new List<Platforms>();
            foreach (string plat in game.Platforms.Split(';'))
            {
                platList.Add((from p in db.Platform
                              where p.Name == plat
                              select p).SingleOrDefault());
            }

            db.Games.Add(new Games{
                Name = game.Name,
                Description = game.Description,
                PubYear = game.PubYear,
                Link_ID = (from link in db.Links
                           where link.Link == game.Link
                           select link.ID).SingleOrDefault(),
                Publisher_ID = (from pub in db.Publisher
                                where pub.Name == game.Publisher
                                select pub.ID).SingleOrDefault(),
                Platforms = platList,
                Developers = devList,
                Genres = genList,
                Rating_ID = (from rat in db.Rating
                             where rat.Score == game.Score
                             select rat.ID).SingleOrDefault()
            });

            db.SaveChanges();
        }

        public void FromCsv(string path, char seperator)
        {
            string line;
            StreamReader streamReader = new StreamReader(path);

            using (var db = new GameRatingsDbContext())
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(seperator);

                    if (!db.Games.Any(g => g.Name.ToUpper() == data[0].ToUpper()))
                    {
                        string[] devs = data[1].Split(',');
                        foreach (string dev in devs)
                        {
                            if (!db.Developer.Any(d => d.Name.ToUpper() == dev.ToUpper()))
                            {
                                db.Developer.Add(new Developers(dev));
                            }
                        }

                        string[] genres = data[2].Split(',');
                        foreach (string genre in genres)
                        {
                            if (!db.Genre.Any(g => g.Name.ToUpper() == genre.ToUpper()))
                            {
                                db.Genre.Add(new Genres(genre));
                            }
                        }

                        if (!db.Publisher.Any(p => p.Name.ToUpper() == data[3].ToUpper()))
                        {
                            db.Publisher.Add(new Publishers(data[3]));
                        }

                        string[] platforms = data[5].Split(',');
                        foreach (string platform in platforms)
                        {
                            if (!db.Platform.Any(p => p.Name == platform))
                            {
                                db.Platform.Add(new Platforms(platform));
                            }
                        }

                        if (!db.Links.Any(l => l.Link == data[7]))
                        {
                            db.Links.Add(new Links(data[7]));
                        }

                        db.SaveChanges();

                        List<Developers> devList = new List<Developers>();
                        foreach (string dev in devs)
                        {
                            devList.Add((from d in db.Developer
                                         where d.Name == dev
                                         select d).SingleOrDefault());
                        }

                        List<Genres> genreList = new List<Genres>();
                        foreach (string genre in genres)
                        {
                            genreList.Add((from g in db.Genre
                                           where g.Name == genre
                                           select g).SingleOrDefault());
                        }

                        List<Platforms> platformList = new List<Platforms>();
                        foreach (string platform in platforms)
                        {
                            platformList.Add((from p in db.Platform
                                              where p.Name == platform
                                              select p).SingleOrDefault());
                        }

                        db.Games.Add(new Games
                        {
                            Name = data[0],
                            Developers = devList,
                            Genres = genreList,
                            Publisher_ID = (from p in db.Publisher
                                            where p.Name == data[3]
                                            select p.ID).SingleOrDefault(),
                            PubYear = Convert.ToInt32(data[4]),
                            Platforms = platformList,
                            Description = data[6],
                            Link_ID = (from l in db.Links
                                       where l.Link == data[7]
                                       select l.ID).SingleOrDefault(),
                            Rating_ID = (from r in db.Rating
                                         where r.Score == Convert.ToInt32(data[8])
                                         select r.ID).SingleOrDefault()
                        });

                        db.SaveChanges();
                    }
                }
            }

        }
    }
}
