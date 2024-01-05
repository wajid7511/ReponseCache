using Microsoft.AspNetCore.Mvc;

namespace ReponseCache.Controllers;

[ApiController]
[Route("[controller]")]
[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    { 
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet]
    [Route("GetFirst")]
    public WeatherForecast GetFirst()
    { 
        var newObject = new WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
        return newObject;
    }

    [HttpGet]
    [Route("GetLast")]
    public WeatherForecast GetLast()
    { 
        var newObject = new WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
        return newObject;
    }
}

