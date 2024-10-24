using BlazorDiscovery.Infrastructure.Persistence.Contexts;
using BlazorDiscovery.Infrastructure.Persistence.Repositories;
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
else
{
    builder.Services.AddDbContext<MongoDbContext>();
    builder.Services.AddScoped<IPersonRepository, PersonMongoDbRepository>();
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
