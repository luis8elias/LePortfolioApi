using Microsoft.EntityFrameworkCore;
using LePortfolioApi.Seeders;
using LePortfolioApi.Extensions;
using LePortfolioApi.Data;
using LePortfolioApi.Profiles;
using FluentValidation;
using LePortfolioApi.Validations;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EfContext>(options =>
{
    var connStr = builder.Configuration["Development:ConnectionString"]; ;
    options.UseSqlServer(connStr ?? throw new InvalidOperationException("Connection string 'Ef' not found."));
});

builder.Services.AddAutoMapper(typeof(Profiles));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Validations));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt => opt.InvalidModelStateResponseFactory = AppValidator.MakeValidationResponse);
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
