using EmailService.API.Data;
using EmailService.API.Models;
using EmailService.API.Models.ForecastWeather;
using EmailService.API.Models.CoinRanking;
using Microsoft.EntityFrameworkCore;


namespace EmailService.API.Services
{
    public class ApiService
    {
        private readonly ApiContext _context;
        private readonly IConfiguration _config;
        private readonly Utils.Http _httpClient;

        public ApiService(ApiContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _httpClient = new Utils.Http(_config["RapidApi:ServiceApiKey"]);
            DbInitializer.Initialize(context);
        }

        public IEnumerable<ApiModel> GetAll()
        {
            return _context.ApiList
                .OrderBy(ad => ad.Id)
                .AsNoTracking()
                .ToList();
        }

        public async Task<ApiResponse?> SendRequest(ApiModel api) 
        {
            if (api is null)
            {
                return null;
            }
            return api.ResponseModelType switch
            {
                ResponseModel.WeatherForecast => await _httpClient.SendRequest<ForecastWeatherResponse>(api),
                ResponseModel.Coinranking => await _httpClient.SendRequest<CoinRankingResponse>(api),
                _ => throw new NotImplementedException(),
            };
        }

        public async Task<ApiResponse?> SendRequest(int id)
        {
            var api = _context.ApiList.FirstOrDefault(a => a.Id == id);
            return await SendRequest(api);
        }

        public async Task<ApiResponse?> SendRequest(ResponseModel responseModel)
        {
            var api = _context.ApiList.FirstOrDefault(a => a.ResponseModelType == responseModel);
            return await SendRequest(api);
        }
    }
}
