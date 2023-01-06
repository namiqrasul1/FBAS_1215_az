namespace Customer.Api.Repositories;

public interface ICustomerRepository
{
    List<Models.Customer> GetAll();
    Models.Customer? Get(int id);
    Models.Customer? Insert(Models.Customer product);
}
