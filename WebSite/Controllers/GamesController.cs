using Data.Interfaces;
using Data.Models;
using Data.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.HTTP;

namespace WebSite.Controllers
{
    public class GamesController : Controller
    {
        [BindProperty]
        public string orderName { get; set; }
        private readonly IClientList<List<Games>> client;

        public GamesController(IClientList<List<Games>> client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> Index()
        {
            List<Games> games = new List<Games>();

            games = await client.GetAsync(search);

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

        [BindProperty]
        public string search { get; set; }

        public void OnPost()
        {
        }
    }
}