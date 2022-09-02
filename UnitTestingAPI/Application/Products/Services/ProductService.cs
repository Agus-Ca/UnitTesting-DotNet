using Microsoft.EntityFrameworkCore;

using DemoUnitTesting.Domain;
using UnitTestingAPI.Application.Products.Interfaces;
using UnitTestingAPI.Domain.Entities;
using UnitTestingAPI.Infrastructure.Persistence.Interfaces;



namespace UnitTestingAPI.Application.Products.Services;

public class ProductService : IProductService
{
    private readonly IDatabaseContext _databaseContext;

    public ProductService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Result<Product>> GetByIdAsync(int id)
    {
        var product = await _databaseContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return "ERROR_CODE_G1";
        }

        return product;
    }
}