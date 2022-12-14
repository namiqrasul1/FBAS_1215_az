using EShop.Application.Repositories;
using EShop.Domain.Entities.Common;
using EShop.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EShopDbContext context;

        public ReadRepository(EShopDbContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table => context.Set<T>();

        public async Task<T> Get(string id, bool tracking = true)
        //=> await Table.FindAsync(Guid.Parse(id));
        //=> await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }
        public async Task<T> Get(Expression<Func<T, bool>> method, bool tracking = true)
            => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetAll(bool tracking = true) => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true) => Table.Where(method);
    }
}
