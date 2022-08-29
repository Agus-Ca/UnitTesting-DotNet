using UnitTestingApp.Services;

namespace UnitTestingApp.UnitTests.Services.CalculadoraServiceTests;

public class SumarTests
{
    [Fact]
    public void When_NumbersAreValid_Expect_TheirSum()
    {
        // Arrange
        int number1 = 4;
        int number2 = 5;
        int expectedSum = 9;

        CalculadoraService service = new();

        // Act
        var result = service.Sumar(number1, number2);

        // Assert
        Assert.Equal(expectedSum, result);
    }
}