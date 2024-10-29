using BlazorDiscoveryAPI.Domain.Entities;
using BlazorDiscoveryAPI.Domain.Services;
using BlazorDiscoveryAPI.Infrastructure.Persistence.Base;
using BlazorDiscoveryAPI.Infrastructure.Persistence.Contexts;

namespace BlazorDiscoveryAPI.Infrastructure.Persistence.Repositories
{
    public class PersonPostgresRepository : PostgresBaseRepository<Person>, IPersonRepository
    {
        public PersonPostgresRepository(PostgresContext context) : base(context)
        {
        }
    }
}
