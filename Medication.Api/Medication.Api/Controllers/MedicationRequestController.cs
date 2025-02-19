using Microsoft.AspNetCore.Mvc;

namespace Medication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationRequestController : ControllerBase
    {
        private readonly ILogger<MedicationRequestController> _logger;

        public MedicationRequestController(ILogger<MedicationRequestController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
