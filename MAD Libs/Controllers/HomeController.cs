using MAD_Libs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace MAD_Libs.Controllers
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

        public IActionResult Privacy(string adj1, string verb1, string verb2, string adverb1, string adj2, string verb3, string adverb2)
        {
            ViewBag.adj1 = adj1;
            ViewBag.verb1 = verb1;
            ViewBag.verb2 = verb2;
            ViewBag.adv1 = adverb1;
            ViewBag.adj2 = adj2;
            ViewBag.verb3 = verb3;
            ViewBag.adv2 = adverb2;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}