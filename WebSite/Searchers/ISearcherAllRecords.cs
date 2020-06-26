using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Searchers
{
    public interface ISearcherAllRecords
    {
        List<string> GetDevelopers(GameRatingsDbContext db);
        List<string> GetPublishers(GameRatingsDbContext db);
        List<string> GetGenres(GameRatingsDbContext db);
        List<string> GetPlatforms(GameRatingsDbContext db);
    }
}
