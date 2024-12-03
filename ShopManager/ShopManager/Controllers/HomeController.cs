using Microsoft.AspNetCore.Mvc;
using ShopManager.Models;
using System.Diagnostics;

namespace ShopManager.Controllers
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

        [Route("/404")]
        public IActionResult PageNotfound()
        {
            return View();
        }

        [Route("/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        // Thêm các hành động mới cho controller

        public IActionResult Policy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }
    }
}
