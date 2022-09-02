using Microsoft.EntityFrameworkCore;
using MediatR;

using DemoUnitTesting.Domain;
using UnitTestingAPI.Infrastructure.Persistence;
using UnitTestingAPI.Application.Products.Interfaces;
using UnitTestingAPI.Application.Products.Services;
using UnitTestingAPI.Infrastructure.Persistence.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddMediatR(typeof(Result).Assembly);
builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>
    (options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UnitTestingDatabaseConnection"))
    );

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