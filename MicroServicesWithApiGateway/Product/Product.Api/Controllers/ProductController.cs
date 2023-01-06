using Microsoft.AspNetCore.Mvc;
using Product.Api.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = repository.Get(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Models.Product product)
        {
            var result = repository.Insert(product);
            return Created($"/get/{result?.Id}",result);
        }
    }
}
