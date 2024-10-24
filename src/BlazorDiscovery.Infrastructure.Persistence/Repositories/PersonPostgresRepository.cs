using BlazorDiscovery.Infrastructure.Persistence.Base;
using BlazorDiscovery.Infrastructure.Persistence.Contexts;
using BlazorDiscoveryAPI.Domain.Entities;
using BlazorDiscoveryAPI.Domain.Services;

namespace BlazorDiscovery.Infrastructure.Persistence.Repositories
{
    public class PersonPostgresRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonPostgresRepository(PostgresContext context) : base(context)
        {
        }
    }
}
