using DemoUnitTesting.Domain;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.Application.Products.Interfaces;

public interface IProductService
{
    Task<Result<Product>> GetByIdAsync(int id);
}