using Microsoft.AspNetCore.Mvc;
using MotoGP.Models;
using System.Diagnostics;

namespace MotoGP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Menu()
        {
            Random rand = new Random();
            int num = rand.Next(1,5);

            ViewData["BannerNr."] = num;

            return View();
        }
    }
}
