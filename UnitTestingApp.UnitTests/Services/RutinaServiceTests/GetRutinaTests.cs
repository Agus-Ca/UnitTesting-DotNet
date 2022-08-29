using Moq;
using UnitTestingApp.Enums;
using UnitTestingApp.Interfaces;
using UnitTestingApp.Services;

namespace UnitTestingApp.UnitTests.Services.RutinaServiceTests;

public class GetRutinaTests
{
    [Fact]
    public void When_IsMonday_Expected_LearntAboutUnitTesting()
    {
        // Arrange
        Mock<IClimaService> climaService = new();
        DayOfWeek dayOfWeek = DayOfWeek.Monday;
        string expected = "Aprender unit test";

        RutinaService service = new(climaService.Object);

        // Act
        string result = service.GetRutina(dayOfWeek);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void When_IsFridayAndSunny_Expected_DoExercise()
    {
        // Arrange
        Mock<IClimaService> climaService = new();
        climaService.Setup(x => x.GetClima()).Returns(Clima.Soleado);

        DayOfWeek dayOfWeek = DayOfWeek.Friday;
        string expected = "Hacer ejercicio";

        RutinaService service = new(climaService.Object);

        // Act
        string result = service.GetRutina(dayOfWeek);

        // Assert
        Assert.Equal(expected, result);
    }
}