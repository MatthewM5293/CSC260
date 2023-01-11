using About_me.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace About_me.Controllers
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

            ViewData["Title"] = "About Me";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Before()
        {
            ViewData["Title"] = "Before Neumont";
            return View();
        }
        
        public IActionResult After()
        {
            ViewData["Title"] = "After Neumont";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}