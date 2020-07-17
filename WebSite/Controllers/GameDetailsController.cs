using WebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebSite.HTTP;
using WebSite.ViewModels;
using WebSite.Validators;

namespace WebSite.Controllers
{
    public class GameDetailsController : Controller
    {
        private readonly IBaseValidator stringValidator;
        private readonly IClient<Games> client;

        public GameDetailsController(IBaseValidator stringValidator, IClient<Games> client)
        {
            this.stringValidator = stringValidator ?? throw new ArgumentNullException(nameof(stringValidator));
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> Index(string name, string mode = "")
        {
            Games game = await client.GetAsync(name);

            List<string> devsList = new List<string>();
            List<string> genresList = new List<string>();
            List<string> publishersList = new List<string>();
            List<string> platformsList = new List<string>();

            switch (mode)
            {
                case "edit":
                    this.stringValidator.Validate(name);

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

                    //datalists
                    devsList = await client.GetDevelopers();
                    genresList = await client.GetGenres();
                    platformsList = await client.GetPlatforms();
                    publishersList = await client.GetPublishers();

                    return View(new GamesViewModel
                    {
                        Id = game.ID,
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

                case "new":

                    //datalists
                    devsList = await client.GetDevelopers();
                    genresList = await client.GetGenres();
                    platformsList = await client.GetPlatforms();
                    publishersList = await client.GetPublishers();

                    return View(new GamesViewModel
                    {
                        DevList = devsList,
                        PublisherList = publishersList,
                        PlatformList = platformsList,
                        GenreList = genresList,
                        Mode = 'n'
                    });

                default:
                    if (!this.stringValidator.Validate(name))
                    {
                        RedirectToAction("Index");
                    }

                    i = 0;
                    developers = "";
                    foreach (Developers devs in game.Developers)
                    {
                        developers += devs.Name;
                        if (i < game.Developers.Count - 1)
                        {
                            developers += ", ";
                        }
                        i++;
                    }

                    i = 0;
                    genres = "";
                    foreach (Genres genre in game.Genres)
                    {
                        genres += genre.Name;
                        if (i < game.Genres.Count - 1)
                        {
                            genres += ", ";
                        }
                        i++;
                    }

                    i = 0;
                    platforms = "";
                    foreach (Platforms platform in game.Platforms)
                    {
                        platforms += platform.Name;
                        if (i < game.Platforms.Count - 1)
                        {
                            platforms += ", ";
                        }
                        i++;
                    }

                    ViewData["img"] = "~/img/" + game.Name + ".jpg";

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
                        PubYear = game.PubYear,
                        Mode = 'd'
                    });
            }
        }

        public async Task<IActionResult> Delete(GamesViewModel gamesModel)
        {
            await client.DeleteAsync(gamesModel.Id);
            return RedirectToAction("Index", "Games");
        }

        public async Task<IActionResult> SaveChanges(GamesViewModel gamesModel, [FromForm(Name = "imgFile")] IFormFile imgFile)
        {
            if (imgFile != null)
            {
                imgFile.CopyTo(new FileStream(Path.Combine("../WebSite/img", gamesModel.Name + ".jpg"), FileMode.Create));
            }

            if (gamesModel.Id <= 0)
            {
                await client.PostAsync(gamesModel);
            }
            else
            {
                await client.PutAsync(gamesModel);
            }
            return RedirectToAction("Index", "GameDetails", new { name = gamesModel.Name });
        }
    }
}