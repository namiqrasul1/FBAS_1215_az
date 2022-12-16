using EShop.Application.Features.Commands.Products.AddProduct;
using EShop.Application.Features.Queries.Products.GetAllProducts;
using EShop.Application.Repositories.ProductRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using MediatR;
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
        private readonly IMediator mediator;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMediator mediator)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
            this.mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetProductsQueryRequest request)
        {
            //baseurl/api/products/getall
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);

            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddProductCommandRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await mediator.Send(request);


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
