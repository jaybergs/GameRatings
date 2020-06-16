using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebSite.Controllers
{
    public class GameDetailsController : Controller
    {
        public IActionResult Index(string name)
        {
            using (var db = new GameRatingsDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var game = (from gm in db.Games
                                .Include("Developers")
                                .Include("Genres")
                                .Include("Platforms")
                                .Include("Publisher")
                                .Include("Rating")
                                .Include("Link")
                            where gm.Name == name
                            select gm).FirstOrDefault();

                ViewData["img"] = "~/img/" + game.Name + ".jpg";
                return View(game);
            }
        }
    }
}