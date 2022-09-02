using AutoFixture;
using UnitTestingAPI.Application.Products.Services;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.UnitTests.Application.Products.Services.ProductServiceTests;

[Trait("Products - GetById", "Unit tests for GetById use case")]
public class GetByIdAsyncTests
{

    [Fact]
    public async Task When_ProductExists_Expect_ReturnSuccess()
    {
        // Arrange
        MockObject mockObject = new();

        var product = mockObject.Fixture.Create<Product>();
        mockObject.ApplicationContext.Products.Add(product);
        await mockObject.ApplicationContext.SaveChangesAsync(default);

        ProductService service = new ProductService(
            mockObject.ApplicationContext);

        // Act
        var actual = await service.GetByIdAsync(product.Id);

        // Assert
        Assert.True(actual.Succeeded);
    }

    [Fact]
    public async Task When_ProductNotExists_Expect_ReturnErrorCodeG1()
    {
        // Arrange
        MockObject mockObject = new();

        ProductService service = new( mockObject.ApplicationContext );

        // Act
        var actual = await service.GetByIdAsync( mockObject.Fixture.Create<int>() );

        // Assert
        Assert.False( actual.Succeeded );
        Assert.Equal( "ERROR_CODE_G1", actual.Error );
    }
}