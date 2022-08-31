namespace UnitTestingAPI.Application.Products.Commands.AddProduct;

public record AddProductResponse(int Id, string Name, string Description, decimal Price, bool IsActive);