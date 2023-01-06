namespace Customer.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private static readonly List<Models.Customer> customers = new()
        {
            new(){Id = 1, Name = "Murad", Surname="Musayev" },
            new(){Id = 1, Name = "Parvin", Surname="Aliyev" },
            new(){Id = 1, Name = "Hesen", Surname="Rzayev" },
            new(){Id = 1, Name = "Zaur", Surname="Aliyev" }
        };

    public Models.Customer? Get(int id) => customers.FirstOrDefault(p => p.Id == id);

    public List<Models.Customer> GetAll() => customers;

    public Models.Customer? Insert(Models.Customer customer)
    {
        var maxId = customers.Max(x => x.Id);
        customer.Id = ++maxId;
        customers.Add(customer);
        return customer;
    }
}
