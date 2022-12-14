using EShop.Application.Repositories;
using EShop.Application.Repositories.OrderRepository;
using EShop.Domain.Entities;
using EShop.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(EShopDbContext context) : base(context)
        {
        }
    }
}
