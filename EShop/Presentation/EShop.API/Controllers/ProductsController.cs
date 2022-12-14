using EShop.Application.Paginations;
using EShop.Application.Repositories.ProductRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
        }

        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] Pagination pagination)
        {
            //baseurl/api/products/getall
            try
            {
                var totalCount = productReadRepository.GetAll(tracking: false).Count();
                var products = productReadRepository.GetAll(tracking: false).OrderBy(product => product.CreatedTime).Skip(pagination.Size * pagination.Page).Take(pagination.Size);

                return Ok(new { products, totalCount });

            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Description = model.Desc,
                        Price = model.Price,
                        Stock = model.Stock
                    };
                    await productWriteRepository.AddAsync(product);
                    await productWriteRepository.SaveChangesAsync();

                    return StatusCode((int)HttpStatusCode.Created);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        


        //[HttpGet]
        //public async Task Get()
        //{
        //    await productWriteRepository.AddRangeAsync(new()
        //    {
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Product", Stock  = 1, Description = "Babat", Price = 5.6m},
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Product1", Stock  = 2, Description = "Babat1", Price = 51.6m},
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Product2", Stock  = 3, Description = "Babat2", Price = 54.6m},
        //    });
        //    await productWriteRepository.SaveChangesAsync();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var product = await productReadRepository.Get(id, tracking: false);
        //    product.Description = "chox chox babat product";
        //    await productWriteRepository.SaveChangesAsync();
        //    return Ok(product);
        //}
    }
}
