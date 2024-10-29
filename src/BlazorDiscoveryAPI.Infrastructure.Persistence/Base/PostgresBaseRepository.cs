using BlazorDiscoveryAPI.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace BlazorDiscoveryAPI.Infrastructure.Persistence.Base
{
    public class PostgresBaseRepository<T> : IBaseRepository<T> where T : AggregateRoot
    {
        private readonly DbContext Context;
        protected readonly DbSet<T> DbSet;
        public PostgresBaseRepository(DbContext context)
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
            await DbSet.AddAsync(entity);
        }

        public Task Delete(T entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}
