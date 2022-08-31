using MediatR;

using DemoUnitTesting.Domain;
using UnitTestingAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.Application.Products.Commands.AddProduct;

public class AddProductRequestHandler : IRequestHandler<AddProductRequest, Result<AddProductResponse>>
{
    private readonly DatabaseContext _database;

    public AddProductRequestHandler(DatabaseContext database)
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