using Cashingaspnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Cashingaspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMemoryCache _memoryCache;

        IEmployeetRepository _employeetRepository;
       

       

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMemoryCache memoryCache, AppDbContext context,
            IEmployeetRepository employeetRepository)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _employeetRepository = employeetRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var cacheKey = "employeeList";
            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out List<EmployeeDTO> employeeList))
            {
                //calling the server
                employeeList = await _employeetRepository.GetEmployees();

                //setting up cache options
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                //setting cache entries
                _memoryCache.Set(cacheKey, employeeList, cacheExpiryOptions);
            }
            return Ok(employeeList);
        }
    }
}