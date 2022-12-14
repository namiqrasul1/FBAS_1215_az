using EShop.Application.Repositories;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Domain.Entities;
using EShop.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Repositories.CustomerRepository
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(EShopDbContext context) : base(context)
        {
        }
    }
}
