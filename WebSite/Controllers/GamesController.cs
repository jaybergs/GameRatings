using Data.Interfaces;
using Data.Models;
using Data.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebSite.Controllers
{
    public class GamesController : Controller
    {
        [BindProperty]
        public string orderName { get; set; }
        public IActionResult Index()
        {
            using (var db = new GameRatingsDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                ISearcher searcher = new Searcher(db);
                IList<Games> games;
                if (string.IsNullOrEmpty(search))
                {
                    games = db.Games
                        .Include("Developers")
                        .Include("Genres")
                        .Include("Platforms")
                        .Include("Publisher")
                        .Include("Rating").ToList();
                }
                else
                {
                    games = searcher.SearchNames(search);
                }

                switch (orderName)
                {
                    case "nameasc":
                        games = games.OrderBy(g => g.Name).ToList();
                        break;
                    case "namedesc":
                        games = games.OrderByDescending(g => g.Name).ToList();
                        break;
                    case "publisherasc":
                        games = games.OrderBy(g => g.Publisher.Name).ToList();
                        break;
                    case "publisherdesc":
                        games = games.OrderByDescending(g => g.Publisher.Name).ToList();
                        break;
                    case "ratingasc":
                        games = games.OrderBy(g => g.Rating.Score).ToList();
                        break;
                    case "ratingdesc":
                        games = games.OrderByDescending(g => g.Rating.Score).ToList();
                        break;
                    default:
                        games = games.OrderBy(g => g.Name).ToList();
                        break;
                }

                if (string.IsNullOrEmpty(search))
                {
                    ViewData["search"] = "";
                }
                else
                {
                    ViewData["search"] = search;
                }

                return View(games);
            }
        }

        [BindProperty]
        public string search { get; set; }
        public void OnPost()
        {
        }
    }
}