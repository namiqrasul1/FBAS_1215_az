using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FirstMvc.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> _products = new();

        public ProductController()
        {
            _products.Add(new Product() { Title = "product 1", Price = 2 });
            _products.Add(new Product() { Title = "product 2", Price = 4 });
            _products.Add(new Product() { Title = "product 3", Price = 6 });
        }

        public IActionResult Get()
        {
            Product product = new() { Title = "Coca Cola", Price = 0.9 };
            //return View(product);
            //ViewBag.Product = product;
            //ViewData["Product"] = product;
            var json = JsonSerializer.Serialize(product);
            TempData["Product"] = json;
            return View();
        }

        public IActionResult GetAll()
        {
            return View(_products);
        }

        public IActionResult Delete()
        {
            var p = TempData["Product"]?.ToString() ?? "";
            var obj = JsonSerializer.Deserialize<Product>(p);

            return View();
        }
    }
}
