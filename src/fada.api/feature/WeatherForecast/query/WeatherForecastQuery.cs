using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using fada.api.feature.WeatherForecast.domain;
using MediatR;

namespace fada.api.feature.WeatherForecast.query
{
    public class WeatherForecastQuery : IRequest<WeatherForecastResponse>{}

    public class WeatherForecastQueryHandler : IRequestHandler<WeatherForecastQuery, WeatherForecastResponse>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        

        public async Task<WeatherForecastResponse> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var results = Enumerable.Range(1, 5).Select(index => new WeatherForecastItem
            {
                Date = DateTime.Now.AddDays(index),                
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return await Task.FromResult<WeatherForecastResponse>(new WeatherForecastResponse(){Results = results });    

        }
    }
}