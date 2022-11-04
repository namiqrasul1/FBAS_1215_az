using Microsoft.AspNetCore.Mvc;
using SencondMvc.Models;

namespace SencondMvc.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new();
        public IActionResult GetAll()
        {
            return View(products);
        }

        public IActionResult Get(Product product)
        {
            
            return View();
        }

        //public IActionResult Get()
        //{
        //    var a = Request.Query["a"].ToString();
        //    var b = Request.Query["b"].ToString();
        //    return View();
        //}

        //public IActionResult Get(string a, string b) { return View(); }

        public IActionResult Delete() { return View(); }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            products.Add(product);
            return RedirectToAction("GetAll");
        }
    }
}
