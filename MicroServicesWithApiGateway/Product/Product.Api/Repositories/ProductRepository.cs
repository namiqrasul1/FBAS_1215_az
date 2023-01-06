namespace Product.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Models.Product> products = new()
        {
            new(){Id = 1, Name = "Telefon"},
            new(){Id = 2, Name = "Notebook"},
            new(){Id = 3, Name = "PowerBank"},
            new(){Id = 4, Name = "Headphones"},
        };

        public Models.Product? Get(int id) => products.FirstOrDefault(p => p.Id == id);

        public List<Models.Product> GetAll() => products;

        public Models.Product? Insert(Models.Product product)
        {
            var maxId = products.Max(x => x.Id);
            product.Id = ++maxId;
            products.Add(product);
            return product;
        }
    }
}
