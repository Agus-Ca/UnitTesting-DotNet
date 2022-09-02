using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using UnitTestingAPI.Application.Products.Commands.AddProduct;
using UnitTestingAPI.Domain.Entities;

namespace UnitTestingAPI.UnitTests.Application.Products.Commands.AddProduct;



[Trait("Products - AddProduct", "Unit tests for AddProduct use case")]
public class AddProductRequestHandlerTests
{
    [Theory, AutoData]
    public async Task When_ValidRequest_Expect_ReturnSuccess( AddProductRequest request )
    {
        // Arrange
        MockObject mockObject = new();

        var handler = new AddProductRequestHandler(mockObject.ApplicationContext);

        // Act
        var actual = await handler.Handle( request, It.IsAny<CancellationToken>() );

        // Assert
        Assert.True( actual.Succeeded );
    }

    [Fact]
    public async Task When_NameIsEmpty_Expect_ReturnErrorCodeA1()
    {
        // Arrange
        MockObject mockObject = new();
        var handler = new AddProductRequestHandler( mockObject.ApplicationContext );
        var request = new AddProductRequest("", mockObject.Fixture.Create<string>(), mockObject.Fixture.Create<decimal>() );

        // Act
        var actual = await handler.Handle( request, It.IsAny<CancellationToken>() );

        //Assert
        Assert.False( actual.Succeeded );
        Assert.Equal( "ERROR_CODE_A1", actual.Error );
    }

    [Fact]
    public async Task When_DescriptionIsShort_Expect_ReturnErrorCodeA2()
    {
        // Arrange
        MockObject mockObject = new();
        var handler = new AddProductRequestHandler( mockObject.ApplicationContext );
        var request = new AddProductRequest( mockObject.Fixture.Create<string>(), "A", mockObject.Fixture.Create<decimal>() );

        // Act
        var actual = await handler.Handle( request, It.IsAny<CancellationToken>() );

        // Assert
        Assert.False( actual.Succeeded );
        Assert.Equal( "ERROR_CODE_A2", actual.Error );
    }

    [Fact]
    public async Task When_PriceIsEqualsOrLessThanZero_Expect_ReturnErrorCodeA3()
    {
        // Arrange
        MockObject mockObject = new();
        var handler = new AddProductRequestHandler( mockObject.ApplicationContext );
        var request = new AddProductRequest( mockObject.Fixture.Create<string>(), mockObject.Fixture.Create<string>(), 0 );

        // Act
        var actual = await handler.Handle( request, It.IsAny<CancellationToken>() );

        // Assert
        Assert.False( actual.Succeeded );
        Assert.Equal( "ERROR_CODE_A3", actual.Error );
    }

    [Fact]
    public async Task When_NameAlreadyExist_Expect_ReturnErrorCodeA4()
    {
        // Arrange
        MockObject mockObject = new();
        var product = mockObject.Fixture.Create<Product>();
        mockObject.ApplicationContext.Products.Add( product );
        await mockObject.ApplicationContext.SaveChangesAsync( It.IsAny<CancellationToken>() );
        var request = new AddProductRequest( product.Name, mockObject.Fixture.Create<string>(), mockObject.Fixture.Create<decimal>() );
        var handler = new AddProductRequestHandler( mockObject.ApplicationContext );

        // Act
        var actual = await handler.Handle( request, It.IsAny<CancellationToken>());

        // Assert
        Assert.False( actual.Succeeded );
        Assert.Equal( "ERROR_CODE_A4", actual.Error );
    }
}