using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebSite.Models;
using WebSite.Savers;
using WebSite.Searchers;
using WebSite.Validators;

namespace WebSite.Controllers
{
    public class GameDetailsController : Controller
    {
        private readonly IBaseValidator stringValidator;
        private readonly ISaverNewRecords saverNewRecords;
        private readonly ISaverGames saverGames;
        private readonly ISearcherAllRecords searcherAllRecords;
        private readonly ISaverNewGames saverNewGames;

        public GameDetailsController(IBaseValidator stringValidator, ISaverNewRecords saverNewRecords, ISaverGames saverGames,
            ISearcherAllRecords searcherAllRecords, ISaverNewGames saverNewGames)
        {
            this.stringValidator = stringValidator ?? throw new ArgumentNullException(nameof(stringValidator));
            this.saverNewRecords = saverNewRecords ?? throw new ArgumentNullException(nameof(saverNewRecords));
            this.saverGames = saverGames ?? throw new ArgumentNullException(nameof(saverGames));
            this.searcherAllRecords = searcherAllRecords ?? throw new ArgumentNullException(nameof(searcherAllRecords));
            this.saverNewGames = saverNewGames;
        }

        public IActionResult Index(string name, string mode = "")
        {
            switch (mode)
            {
                case "edit":
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

                        string platforms = "";
                        i = 0;
                        foreach (Platforms platform in game.Platforms)
                        {
                            platforms += platform.Name;
                            if (i < game.Platforms.Count - 1)
                            {
                                platforms += ";";
                            }
                            i++;
                        }

                        //ViewData für datalists
                        List<string> devsList = new List<string>();
                        foreach (Developers dev in db.Developer)
                        {
                            devsList.Add(dev.Name);
                        }

                        List<string> genresList = new List<string>();
                        foreach (Genres genre in db.Genre)
                        {
                            genresList.Add(genre.Name);
                        }

                        List<string> platformsList = new List<string>();
                        foreach (Platforms platform in db.Platform)
                        {
                            platformsList.Add(platform.Name);
                        }

                        List<string> publishersList = new List<string>();
                        foreach (Publishers publisher in db.Publisher)
                        {
                            publishersList.Add(publisher.Name);
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
                            Platforms = platforms,
                            DevList = devsList,
                            GenreList = genresList,
                            PlatformList = platformsList,
                            PublisherList = publishersList,
                            PubYear = game.PubYear,
                            Mode = Convert.ToChar("e")
                        });
                    }

                case "new":
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

                    return View(new GamesViewModel
                    {
                        DevList = devList,
                        PublisherList = publisherList,
                        GenreList = genreList,
                        PlatformList = platformList,
                        Mode = 'n'
                    });

                default:
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

                        string platforms = "";
                        i = 0;
                        foreach (Platforms platform in game.Platforms)
                        {
                            platforms += platform.Name;
                            if (i < game.Platforms.Count - 1)
                            {
                                platforms += ";";
                            }
                            i++;
                        }

                        ViewData["img"] = "~/img/" + game.Name + ".jpg";
                        return View(new GamesViewModel {
                            Name = game.Name,
                            Developers = developers,
                            Genres = genres,
                            Link = game.Link.Link,
                            Publisher = game.Publisher.Name,
                            Score = game.Rating.Score,
                            Description = game.Description,
                            Platforms = platforms,
                            PubYear = game.PubYear,
                            Mode = 'd'
                        });
                    }

            }

        }

        public IActionResult SaveChanges(GamesViewModel gamesModel, [FromForm(Name = "imgFile")] IFormFile imgFile)
        {
            using (var db = new GameRatingsDbContext())
            {
                if (db.Games.Any(g => g.Name == gamesModel.Name))
                {
                    this.saverNewRecords.Save(gamesModel, db);

                    this.saverGames.Save(gamesModel, db);

                    if (imgFile != null)
                    {
                        imgFile.CopyTo(new FileStream(Path.Combine("../WebSite/img", gamesModel.Name + ".jpg"), FileMode.Create));
                    }

                    return RedirectToAction("Index", "GameDetails", new { name = gamesModel.Name });
                }
                else
                { 
                    saverNewGames.Save(gamesModel, db);
                    if (imgFile != null)
                    {
                        imgFile.CopyTo(new FileStream(Path.Combine("../WebSite/img", gamesModel.Name + ".jpg"), FileMode.Create));
                    }

                    return RedirectToAction("Index", "GameDetails", new { name = gamesModel.Name });
                }

            }

        }
    }
}