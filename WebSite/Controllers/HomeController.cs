using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using WebSite.Models;
using System.Linq;
using System.Net.Http;
using WebSite.HTTP;
using System;
using System.Threading.Tasks;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientList<List<Games>> client;

        public HomeController(ILogger<HomeController> logger, IClientList<List<Games>> client)
        {
            _logger = logger;
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IActionResult> Index()
        {
            List<string> imgNames = new List<string>();
            List<Games> games = await client.GetHighestAsync(5);

            foreach(Games game in games)
            {
                imgNames.Add(game.Name);
            }

            return View(imgNames);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}