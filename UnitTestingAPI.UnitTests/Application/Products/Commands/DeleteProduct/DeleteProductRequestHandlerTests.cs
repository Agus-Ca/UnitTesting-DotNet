using AutoFixture;
using Moq;
using UnitTestingAPI.Application.Products.Commands.DeleteProduct;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.UnitTests.Application.Products.Commands.DeleteProduct;

[Trait("Products - DeleteProduct", value: "Unit tests for DeleteProduct use case")]
public class DeleteProductRequestHandlerTests
{
    [Fact]
    public async Task When_ProductExists_Expect_ReturnSuccess()
    {
        // Arrange
        MockObject mockObject = new();

        var product = mockObject.Fixture.Create<Product>();

        mockObject.ApplicationContext.Products.Add(product);
        await mockObject.ApplicationContext.SaveChangesAsync(It.IsAny<CancellationToken>());

        DeleteProductRequest request = new(product.Id);

        var handler = new DeleteProductRequestHandler(mockObject.ApplicationContext);

        // Act
        var actual = await handler.Handle(request, default);

        // Assert
        Assert.True(actual.Succeeded);
    }

    [Fact]
    public async Task When_ProductNotExists_Expect_ReturnErrorCodeD1()
    {
        // Arrange
        MockObject mockObject = new();

        DeleteProductRequest request = new(mockObject.Fixture.Create<int>());

        var handler = new DeleteProductRequestHandler(mockObject.ApplicationContext);

        // Act
        var actual = await handler.Handle(request, default);

        // Assert
        Assert.False(actual.Succeeded);
        Assert.Equal("ERROR_CODE_D1", actual.Error);
    }
}