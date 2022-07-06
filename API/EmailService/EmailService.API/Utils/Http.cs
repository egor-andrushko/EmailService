using EmailService.API.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EmailService.API.Utils
{
    public class Http
    {
        private HttpClient _client;
        private string _apiKey;
        public Http(string apiKey)
        {
            _apiKey = apiKey;
            _client = new HttpClient();
        }
        public async Task<ApiType?> SendRequest<ApiType>(ApiModel api)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", api.BaseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ApiType? apiResponse = default;
            string requestUrl = api.RequestUrl + string.Concat(api.RequiredParams.Select(p => $"?{p.Key}={p.Value}"));
            HttpResponseMessage response = await _client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                apiResponse = await response.Content.ReadFromJsonAsync<ApiType>(options);
            }
            return apiResponse;
        }
    }
}
