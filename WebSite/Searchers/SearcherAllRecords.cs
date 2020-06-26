using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Searchers
{
    public class SearcherAllRecords : ISearcherAllRecords
    {
        public List<string> GetDevelopers(GameRatingsDbContext db)
        {
            List<string> devList = new List<string>();

            foreach (Developers dev in db.Developer)
            {
                devList.Add(dev.Name);
            }

            return devList;
        }

        public List<string> GetGenres(GameRatingsDbContext db)
        {
            List<string> genreList = new List<string>();

            foreach (Genres genre in db.Genre)
            {
                genreList.Add(genre.Name);
            }

            return genreList;
        }

        public List<string> GetPlatforms(GameRatingsDbContext db)
        {
            List<string> platformList = new List<string>();

            foreach (Platforms platform in db.Platform)
            {
                platformList.Add(platform.Name);
            }

            return platformList;
        }

        public List<string> GetPublishers(GameRatingsDbContext db)
        {
            List<string> publisherList = new List<string>();

            foreach (Publishers publisher in db.Publisher)
            {
                publisherList.Add(publisher.Name);
            }

            return publisherList;
        }
    }
}
