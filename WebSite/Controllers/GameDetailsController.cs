using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSite.Models;
using WebSite.Savers;
using WebSite.Validators;

namespace WebSite.Controllers
{
    public class GameDetailsController : Controller
    {
        private readonly IBaseValidator stringValidator;
        private readonly ISaverNewRecords saverNewRecords;
        private readonly ISaverGames saverGames;

        public GameDetailsController(IBaseValidator stringValidator, ISaverNewRecords saverNewRecords, ISaverGames saverGames)
        {
            this.stringValidator = stringValidator ?? throw new ArgumentNullException(nameof(stringValidator));
            this.saverNewRecords = saverNewRecords ?? throw new ArgumentNullException(nameof(saverNewRecords));
            this.saverGames = saverGames ?? throw new ArgumentNullException(nameof(saverGames));
        }

        public IActionResult Index(string name)
        {
            if (!this.stringValidator.Validate(name))
            {
                RedirectToAction("Index");
            }
            
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
            this.stringValidator.Validate(name);
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

                string developers = "";
                int i = 0;
                foreach (Developers dev in game.Developers)
                {
                    developers += dev.Name;
                    if (i < game.Developers.Count - 1)
                    {
                        developers += ";";
                    }
                    i++;
                }

                string genres = "";
                i = 0;
                foreach (Genres gen in game.Genres)
                {
                    genres += gen.Name;
                    if (i < game.Genres.Count - 1)
                    {
                        genres += ";";
                    }
                    i++;
                }

                //ViewData für datalists
                List<string> devList = new List<string>();
                foreach (Developers dev in db.Developer)
                {
                    devList.Add(dev.Name);
                }

                List<string> genreList = new List<string>();
                foreach (Genres genre in db.Genre)
                {
                    genreList.Add(genre.Name);
                }

                List<string> platformList = new List<string>();
                foreach (Platforms platform in db.Platform)
                {
                    platformList.Add(platform.Name);
                }

                List<string> publisherList = new List<string>();
                foreach (Publishers publisher in db.Publisher)
                {
                    publisherList.Add(publisher.Name);
                }

                return View(new GamesViewModel
                {
                    Name = game.Name,
                    Developers = developers,
                    Genres = genres,
                    Link = game.Link.Link,
                    Publisher = game.Publisher.Name,
                    Score = game.Rating.Score,
                    Description = game.Description,
                    DevList = devList,
                    GenreList = genreList,
                    PlatformList = platformList,
                    PublisherList = publisherList
                });
            }
        }

        public IActionResult SaveChanges(GamesViewModel gamesModel)
        {
            using (var db = new GameRatingsDbContext())
            {
                this.saverNewRecords.Save(gamesModel, db);

                this.saverGames.Save(gamesModel, db);

                return RedirectToAction("Index", "GameDetails", new { name = gamesModel.Name });
            }

        }
    }
}