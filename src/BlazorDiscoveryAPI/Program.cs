using BlazorDiscoveryAPI.Infrastructure.Persistence.Contexts;
using BlazorDiscoveryAPI.Infrastructure.Persistence.Repositories;
using BlazorDiscoveryAPI.Application;
using BlazorDiscoveryAPI.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ResolveApplication();

if (builder.Configuration["DatabaseType"] == "Postgres")
{
    builder.Services.AddDbContext<PostgresContext>();
    builder.Services.AddScoped<IPersonRepository, PersonPostgresRepository>();
}
else if (builder.Configuration["DatabaseType"] == "MongoDb")
{
    builder.Services.AddDbContext<MongoDbContext>();
    builder.Services.AddScoped<IPersonRepository, PersonMongoDbRepository>();
    MongoDbContext.Map();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
