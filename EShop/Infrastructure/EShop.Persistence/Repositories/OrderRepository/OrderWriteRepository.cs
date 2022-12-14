using EShop.Application.Repositories.OrderRepository;
using EShop.Domain.Entities;
using EShop.Persistence.Contexts;

namespace EShop.Persistence.Repositories.OrderRepository
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(EShopDbContext context) : base(context)
        {
        }
    }
}
