using BlazorDiscoveryAPI.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace BlazorDiscovery.Infrastructure.Persistence.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : AggregateRoot
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;
        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<IList<T>> Get()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await Context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Update(entity);
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}
