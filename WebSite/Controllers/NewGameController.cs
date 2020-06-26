using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;
using WebSite.Savers;
using WebSite.Searchers;

namespace WebSite.Controllers
{
    public class NewGameController : Controller
    {
        private readonly ISaverNewGames saverNewGames;
        private readonly ISearcherAllRecords searcherAllRecords;
        public NewGameController(ISaverNewGames saverNewGames, ISearcherAllRecords searcherAllRecords)
        {
            this.saverNewGames = saverNewGames;
            this.searcherAllRecords = searcherAllRecords;
        }

        public IActionResult Index()
        {
            List<string> devList = new List<string>();
            List<string> publisherList = new List<string>();
            List<string> genreList = new List<string>();
            List<string> platformList = new List<string>();
            using (var db = new GameRatingsDbContext())
            {
                devList = searcherAllRecords.GetDevelopers(db);
                publisherList = searcherAllRecords.GetPublishers(db);
                genreList = searcherAllRecords.GetGenres(db);
                platformList = searcherAllRecords.GetPlatforms(db);
            }

            return View(new NewGameViewModel
            {
                DevList = devList,
                PublisherList = publisherList,
                GenreList = genreList,
                PlatformList = platformList 
            });
        }

        public IActionResult Save(NewGameViewModel game)
        {
            using (var db = new GameRatingsDbContext())
            {
                if (db.Games.Any(g => g.Name == game.Name))
                {
                    return RedirectToAction("Edit", "GameDetails", new { name = game.Name });
                }
                else
                {
                    saverNewGames.Save(game, db);
                    return RedirectToAction("Index", "GameDetails", new { name = game.Name });
                }
            }
        }
    }
}
