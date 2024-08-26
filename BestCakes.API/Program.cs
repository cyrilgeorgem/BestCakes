using BestCakes.DAL;
using BestCakes.DAL.Entities;
using BestCakes.Repositories;
using BestCakes.Repositories.Interfaces;
using BestCakes.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DB context
builder.Services.AddDbContext<BestCakesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BestCakesDBConnection")));

// Register Repositories
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
