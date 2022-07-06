using EmailService.API.Models;

namespace EmailService.API.Models.ForecastWeather
{

    public class ForecastWeatherResponse : ApiResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }
}
