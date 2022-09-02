using Microsoft.EntityFrameworkCore;
using MediatR;

using DemoUnitTesting.Domain;
using UnitTestingAPI.Domain.Entities;
using UnitTestingAPI.Infrastructure.Persistence.Interfaces;




namespace UnitTestingAPI.Application.Products.Commands.AddProduct;

public class AddProductRequestHandler : IRequestHandler<AddProductRequest, Result<AddProductResponse>>
{
    private readonly IDatabaseContext _database;

    public AddProductRequestHandler(IDatabaseContext database)
    {
        _database = database;
    }

    public async Task<Result<AddProductResponse>> Handle(AddProductRequest request, CancellationToken cancellationToken)
    {
        if (request.Name.Length < 3)
        {
            return "ERROR_CODE_A1";
        }

        if (request.Description.Length < 3)
        {
            return "ERROR_CODE_A2";
        }

        if (request.Price <= 0)
        {
            return "ERROR_CODE_A3";
        }

        bool existProductName = await _database.Products.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (existProductName)
        {
            return "ERROR_CODE_A4";
        }

        Product product = new(request.Name, request.Description, request.Price, true);

        _database.Products.Add(product);

        await _database.SaveChangesAsync(cancellationToken);

        return new AddProductResponse(product.Id, product.Name, product.Description, product.Price, product.IsActive);
    }
}