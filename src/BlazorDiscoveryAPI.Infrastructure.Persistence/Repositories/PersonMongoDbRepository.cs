using BlazorDiscoveryAPI.Domain.Entities;
using BlazorDiscoveryAPI.Domain.Services;
using BlazorDiscoveryAPI.Infrastructure.Persistence.Contexts;
using MongoDB.Driver;

namespace BlazorDiscoveryAPI.Infrastructure.Persistence.Repositories
{
    public class PersonMongoDbRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> _collection;
        
        public PersonMongoDbRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<Person>("person");
        }
        
        public async Task<IList<Person>> Get() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Person?> GetById(Guid id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Create(Person newBook) =>
            await _collection.InsertOneAsync(newBook);

        public async Task Update(Person person) =>
            await _collection.ReplaceOneAsync(x => x.Id == person.Id, person);

        public async Task Delete(Person person) =>
            await _collection.DeleteOneAsync(x => x.Id == person.Id);

        public Task Commit()
        {
            return Task.CompletedTask;
        }
    }
}
