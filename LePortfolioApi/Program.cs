using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LePortfolioApi.Seeders;
using LePortfolioApi.Extensions;
using LePortfolioApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EfContext>(options =>
{
    var connStr = builder.Configuration["Development:ConnectionString"]; ;
    options.UseSqlServer(connStr ?? throw new InvalidOperationException("Connection string 'Ef' not found."));
});


builder.Services.AddControllers();
builder.Services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.DbInitialize();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
