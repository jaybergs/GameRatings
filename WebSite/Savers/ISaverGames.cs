using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Savers
{
    public interface ISaverGames
    {
        void Save(GamesViewModel games, GameRatingsDbContext db);
    }
}
