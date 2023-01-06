namespace Product.Api.Repositories
{
    public interface IProductRepository
    {
        List<Models.Product> GetAll();
        Models.Product? Get(int id);
        Models.Product? Insert(Models.Product product);
    }
}
