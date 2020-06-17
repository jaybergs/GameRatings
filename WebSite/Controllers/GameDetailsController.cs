using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public IActionResult Edit(string name)
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

        public IActionResult SaveChanges(string name, int score, string developers, string publisher, string description)
        {
            IList<string> devs = developers.Split(';').ToList();
            using (var db = new GameRatingsDbContext())
            {
                if (!db.Publisher.Any(p => p.Name == publisher))
                {
                    db.Publisher.Add(new Publishers(publisher));
                }
                foreach(string dev in devs)
                {
                    if (!db.Developer.Any(d => d.Name == dev))
                    {
                        db.Developer.Add(new Developers(dev));
                    }
                }
                db.SaveChanges();
                var game = db.Games.SingleOrDefault(g => g.Name == name);
                game.Rating_ID = (from scr in db.Rating
                                where scr.Score == score
                                select scr.ID).SingleOrDefault();
                game.Publisher_ID = (from pub in db.Publisher
                                     where pub.Name == publisher
                                     select pub.ID).SingleOrDefault();
                IList<Developers> newDevs = new List<Developers>();
                foreach (string dev in devs)
                {
                    newDevs.Add((from d in db.Developer
                                 where d.Name == dev
                                 select d).SingleOrDefault());
                }
                game.Developers.Clear();
                game.Developers = newDevs;
                game.Description = description;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "GameDetails", new { name = name });
        }
    }
}