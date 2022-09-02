using MediatR;
using Moq;
using UnitTestingAPI.Application.Products.Interfaces;

namespace UnitTestingAPI.UnitTests.Controllers.ProductControllerTests;

internal class MockObject
{
    public MockObject()
    {
        Mediator = new();
        ProductService = new();
    }

    public Mock<IMediator> Mediator { get; set; }
    public Mock<IProductService> ProductService { get; set; }
}