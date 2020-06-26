using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Savers
{
    public interface ISaverNewRecords
    {
        void Save(GamesViewModel gamesModel, GameRatingsDbContext db);
    }
}
