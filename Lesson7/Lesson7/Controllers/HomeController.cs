using Microsoft.AspNetCore.Mvc;

namespace Lesson7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<string> images = new() { @"https://thumbs.dreamstime.com/b/beautiful-rain-forest-ang-ka-nature-trail-doi-inthanon-national-park-thailand-36703721.jpg", @"https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg" };
            ViewBag.Images = images;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
