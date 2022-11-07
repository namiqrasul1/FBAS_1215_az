using Lesson5.Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson5.Validation.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            // if(string.IsNullOrEmpty(product.Name)) chox iyrencdir!!!!!!!!
            if (!ModelState.IsValid)
            {
                return View(product);
            }



            return View();
        }
    }
}
