using BlazorDiscovery.Infrastructure.Persistence.Mappings;
using BlazorDiscoveryAPI.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace BlazorDiscovery.Infrastructure.Persistence.Contexts
{
    public class PostgresContext : DbContext
    {
        private readonly IConfiguration _config;

        public PostgresContext(IConfiguration config)
        {
            _config = config;
            ChangeTracker.StateChanged += UpdateDates;
            ChangeTracker.Tracked += UpdateDates;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonPostgresMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_config.GetConnectionString("MainConnection"));

        public void UpdateDates(object? sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is Entity ent && e.Entry.State == EntityState.Modified)
            {
                ent.LastModificationDate = DateTime.Now;
            }
        }
    }
}
