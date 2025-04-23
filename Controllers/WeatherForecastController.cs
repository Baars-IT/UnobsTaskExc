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
            throw new ArgumentException("The Unobserved Task Exception will occur at Garbage Collection");
        }

        [Route("/g-c", Name = "GarbageCollect")]
        public void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
