using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Utilities
{
    public class Searcher : ISearcher
    {
        private GameRatingsDbContext db;

        public Searcher(GameRatingsDbContext pDb)
        {
            db = pDb;
        }

        public IList<Games> SearchDevelopers(string search, bool descending = false)
        {
            Validation(search);
            var games = (from gms in db.Games
                         .Include("Developers")
                        .Include("Genres")
                        .Include("Platforms")
                        .Include("Publishers")
                        .Include("Ratings")
                         where gms.Developers.Any(d => d.Name.Contains(search))
                         orderby gms.Name
                         select gms).ToList();
            if (descending) games.OrderByDescending(g => g.Name);
            return games;
        }

        public IList<Games> SearchNames(string search, bool descending = false)
        {
            Validation(search);
            var games = (from gms in db.Games
                         .Include("Developers")
                        .Include("Genres")
                        .Include("Platforms")
                        .Include("Publisher")
                        .Include("Rating")
                         where gms.Name.Contains(search)
                         orderby gms.Name
                         select gms).ToList();
            if (descending) games.OrderByDescending(g => g.Name);
            return games;
        }

        public IList<Games> SearchGenres(string search, bool descending = false)
        {
            Validation(search);
            var games = (from gms in db.Games
                        .Include("Developer")
                        .Include("Genre")
                        .Include("Platform")
                        .Include("Publisher")
                        .Include("Rating")
                         where gms.Genres.Any(g => g.Name.Contains(search))
                         orderby gms.Name
                         select gms).ToList();
            if (descending) games.OrderByDescending(g => g.Name);
            return games;
        }

        public IList<Games> SearchPlatforms(string search, bool descending = false)
        {
            Validation(search);
            var games = (from gms in db.Games
                        .Include("Developer")
                        .Include("Genre")
                        .Include("Platform")
                        .Include("Publisher")
                        .Include("Rating")
                         where gms.Platforms.Any(p => p.Name.Contains(search))
                         orderby gms.Name
                         select gms).ToList();
            if (descending) games.OrderByDescending(g => g.Name);
            return games;
        }

        public IList<Games> SearchPublishers(string search, bool descending = false)
        {
            Validation(search);
            var games = (from gms in db.Games
                        .Include("Developer")
                        .Include("Genre")
                        .Include("Platform")
                        .Include("Publisher")
                        .Include("Rating")
                         join pub in db.Publisher
                         on gms.Publisher_ID equals pub.ID
                         where pub.Name.Contains(search)
                         orderby gms.Name
                         select gms).ToList();
            if (descending) games.OrderByDescending(g => g.Name);
            return games;
        }

        private void Validation(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                throw new ArgumentOutOfRangeException("search", "Value must not be null or empty or white space.");
            }
        }
    }
}