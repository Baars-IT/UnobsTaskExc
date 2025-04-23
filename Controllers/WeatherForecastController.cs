using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace UnobsTaskExc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController() : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        [OutputCache]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new ArgumentException("Some exception");
        }

        [Route("/g-c", Name = "GarbageCollect")]
        public void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
