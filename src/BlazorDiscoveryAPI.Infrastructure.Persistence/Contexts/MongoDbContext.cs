using BlazorDiscoveryAPI.Domain.Base;
using BlazorDiscoveryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BlazorDiscoveryAPI.Infrastructure.Persistence.Contexts
{
    public class MongoDbContext : DbContext
    {
        private IMongoDatabase Database;
        
        public MongoDbContext(DbContextOptions<MongoDbContext> options, IConfiguration configuration)
        {
            Database = new MongoClient(configuration["MongoDbSettings:ConnectionString"])
                .GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName) => Database.GetCollection<T>(collectionName);

        public static void Map()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonClassMap.RegisterClassMap<Entity>(classMap =>
            {
                classMap
                    .MapMember(p => p.Id)
                    .SetElementName("_id");
                classMap
                    .MapMember(p => p.CreationDate)
                    .SetElementName("creation_date");
                classMap
                    .MapMember(p => p.LastModificationDate)
                    .SetElementName("last_modification_date");
                classMap.SetIsRootClass(true);
            });
            BsonClassMap.RegisterClassMap<AggregateRoot>(classMap => { });
            BsonClassMap.RegisterClassMap<Person>(classMap =>
            {
                classMap
                    .MapMember(p => p.Name)
                    .SetElementName("name");
                classMap
                    .MapMember(p => p.Document)
                    .SetElementName("document");
                classMap
                    .MapMember(p => p.Phone)
                    .SetElementName("phone");
                classMap
                    .MapMember(p => p.Email)
                    .SetElementName("email");
                classMap
                    .MapMember(p => p.BirthDate)
                    .SetElementName("birth_date")
                    .SetSerializer(new DateTimeSerializer(dateOnly: true));
                classMap
                    .MapMember(p => p.Address)
                    .SetElementName("address");
            });
            
            BsonClassMap.RegisterClassMap<Address>(classMap =>
            {
                classMap
                    .MapMember(p => p.Street)
                    .SetElementName("street");
                classMap
                    .MapMember(p => p.Number)
                    .SetElementName("number");
                classMap
                    .MapMember(p => p.ZipCode)
                    .SetElementName("zipcode");
                classMap
                    .MapMember(p => p.City)
                    .SetElementName("city");
                classMap
                    .MapMember(p => p.State)
                    .SetElementName("state");
            });
        }
    }
}
