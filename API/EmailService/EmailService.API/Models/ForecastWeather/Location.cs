using System.Text.Json.Serialization;

namespace EmailService.API.Models.ForecastWeather
{
    public class Location
    {

        public string Name { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public float Lat { get; set; }

        public float Lon { get; set; }

        [JsonPropertyName("tz_id")]
        public string TzId { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
}
}
