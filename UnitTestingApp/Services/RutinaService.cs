using UnitTestingApp.Enums;
using UnitTestingApp.Interfaces;

namespace UnitTestingApp.Services;

public class RutinaService
{
    private readonly IClimaService _climaService;

    public RutinaService(IClimaService climaService)
    {
        _climaService = climaService;
    }

    public string GetRutina(DayOfWeek dayOfWeek)
    {
        Clima clima = _climaService.GetClima();

        return dayOfWeek switch
        {
            DayOfWeek.Monday => "Aprender unit test",
            DayOfWeek.Tuesday => "Estudiar SQL",
            DayOfWeek.Wednesday => "Arrancar un proyecto millonario",
            DayOfWeek.Thursday => "Fracasar en lo de ayer",
            DayOfWeek.Friday => (clima == Clima.Soleado) ? "Hacer ejercicio" : "Codear alguna app",
            DayOfWeek.Saturday => "Descansar",
            DayOfWeek.Sunday => "Seguir descansando",

            _ => "Trolleado",
        };
    }
}