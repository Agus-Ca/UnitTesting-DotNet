using MediatR;

using DemoUnitTesting.Domain;



namespace UnitTestingAPI.Application.Products.Commands.DeleteProduct;

public record DeleteProductRequest(int Id) : IRequest<Result>;