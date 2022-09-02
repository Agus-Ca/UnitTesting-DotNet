using DemoUnitTesting.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitTestingAPI.Infrastructure.Persistence.Interfaces;

namespace UnitTestingAPI.Application.Products.Commands.DeleteProduct;

public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, Result>
{
    private readonly IDatabaseContext _database;
	public DeleteProductRequestHandler(IDatabaseContext databaseContext)
	{
        _database = databaseContext;
	}

	public async Task<Result> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
	{
        var product = await _database.Products.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return "ERROR_CODE_D1";
        }

        _database.Products.Remove(product);

        await _database.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}