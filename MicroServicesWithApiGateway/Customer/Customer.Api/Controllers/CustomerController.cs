using Microsoft.AspNetCore.Mvc;
using Customer.Api.Repositories;
using Customer.Api.Models;

namespace Customer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository repository;

    public CustomerController(ICustomerRepository repository)
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
        var customer = repository.Get(id);
        return customer == null ? NotFound() : Ok(customer);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Models.Customer customer)
    {
        var result = repository.Insert(customer);
        return Created($"/get/{result?.Id}", result);
    }
}
