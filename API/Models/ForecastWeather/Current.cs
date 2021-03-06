using System.Text.Json.Serialization;

namespace EmailServiceApi.Models.ForecastWeather
{
    public class Current
    {
        [JsonPropertyName("last_updated_epoch")]
        public int? LastUpdatedEpoch { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public double? TempC { get; set; }

        [JsonPropertyName("temp_f")]
        public double? TempF { get; set; }

        [JsonPropertyName("is_day")]
        public int? IsDay { get; set; }

        public Condition Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public double? WindMph { get; set; }

        [JsonPropertyName("wind_kph")]
        public double? WindKph { get; set; }

        [JsonPropertyName("wind_degree")]
        public int? WindDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDir { get; set; }

        [JsonPropertyName("pressure_mb")]
        public double? PressureMb { get; set; }

        [JsonPropertyName("pressure_in")]
        public double? PressureIn { get; set; }

        [JsonPropertyName("precip_mm")]
        public double? PrecipMm { get; set; }

        [JsonPropertyName("precip_in")]
        public double? PrecipIn { get; set; }

        public int? Humidity { get; set; }

        public int? Cloud { get; set; }

        [JsonPropertyName("feelslike_c")]
        public double? FeelslikeC { get; set; }

        [JsonPropertyName("feelslike_f")]
        public double? FeelslikeF { get; set; }

        [JsonPropertyName("vis_km")]
        public double? VisKm { get; set; }

        [JsonPropertyName("vis_miles")]
        public double? VisMiles { get; set; }

        public double? Uv { get; set; }

        [JsonPropertyName("gust_mph")]
        public double? GustMph { get; set; }

        [JsonPropertyName("gust_kph")]
        public double? GustKph { get; set; }
    }
}
