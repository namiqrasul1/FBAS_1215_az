using Lesson8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson8.Controllers
{
    [Route("anasehife")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("hakuna/{id?}/{a?}/{b?}")]
        public IActionResult Index(int id, double a, string b)
        {
            return View();
        }
        
        [Route("mexfilik")]
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