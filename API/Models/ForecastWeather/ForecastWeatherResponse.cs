using EmailServiceApi.Models;

namespace EmailServiceApi.Models.ForecastWeather
{

    public class ForecastWeatherResponse : ApiResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }
}
