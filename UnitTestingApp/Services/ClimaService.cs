using UnitTestingApp.Enums;
using UnitTestingApp.Interfaces;

namespace UnitTestingApp.Services;

public class ClimaService : IClimaService
{
    public Clima GetClima()
    {
        Random random = new();
        int numeroRandom = random.Next(0, 3);

        var clima = Enum.GetValues<Clima>();

        return clima[numeroRandom];
    }
}