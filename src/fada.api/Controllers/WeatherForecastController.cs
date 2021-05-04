using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using fada.api.feature.WeatherForecast.domain;
using fada.api.feature.WeatherForecast.query;

namespace fada.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediatr;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediatr)
        {
            _mediatr = mediatr;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastItem>> Get()
        {
            var query = await _mediatr.Send<WeatherForecastResponse>(new WeatherForecastQuery());
            return query.Results;
        }
    }
}
