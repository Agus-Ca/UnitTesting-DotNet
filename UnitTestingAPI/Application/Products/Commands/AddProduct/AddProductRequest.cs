using DemoUnitTesting.Domain;
using MediatR;

namespace UnitTestingAPI.Application.Products.Commands.AddProduct;

public record AddProductRequest(string Name, string Description, decimal Price) : IRequest<Result<AddProductResponse>>;