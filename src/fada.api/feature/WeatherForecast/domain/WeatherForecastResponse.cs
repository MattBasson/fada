using System.Collections.Generic;


namespace fada.api.feature.WeatherForecast.domain
{
    public class WeatherForecastResponse
    {
        public IEnumerable<WeatherForecastItem> Results { get; set; }
    }
}