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

        public IActionResult SaveChanges(string name, int score, string developers, string publisher, string genres, string description)
        {
            Validation(publisher);
            Validation(developers);
            Validation(description);
            Validation(genres);
            IList<string> devsList = developers.Split(';').ToList();
            IList<string> genresList = genres.Split(';').ToList();
            using (var db = new GameRatingsDbContext())
            {
                if (!db.Publisher.Any(p => p.Name == publisher))
                {
                    db.Publisher.Add(new Publishers(publisher));
                }
                foreach(string dev in devsList)
                {
                    if (!db.Developer.Any(d => d.Name == dev))
                    {
                        db.Developer.Add(new Developers(dev));
                    }
                }
                foreach(string gen in genresList)
                {
                    if (!db.Genre.Any(g => g.Name == gen))
                    {
                        db.Genre.Add(new Genres(gen));
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
                foreach (string dev in devsList)
                {
                    newDevs.Add((from d in db.Developer
                                 where d.Name == dev
                                 select d).SingleOrDefault());
                }
                game.Developers.Clear();
                game.Developers = newDevs;
                IList<Genres> newGenres = new List<Genres>();
                foreach (string gen in genresList)
                {
                    newGenres.Add((from g in db.Genre
                                   where g.Name == gen
                                   select g).SingleOrDefault());
                }
                game.Genres.Clear();
                game.Genres = newGenres;
                game.Description = description;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "GameDetails", new { name = name });
        }

        public void Validation(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentOutOfRangeException("Input must not be null or white space or empty.");
            }
        }
    }
}