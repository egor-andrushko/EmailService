using EmailService.API.Models;

namespace EmailService.API.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApiContext context)
        {
            if (context.ApiList.Any())
            {
                return;
            }


            context.ApiList.Add(new ApiModel
            {
                Title = "Forecast Weather API",
                RequestUrl = "https://weatherapi-com.p.rapidapi.com/forecast.json",
                BaseUrl = "weatherapi-com.p.rapidapi.com",
                RequiredParams = new List<ApiParams>
                {
                    new ApiParams
                    {
                        Key = "q",
                        Value = "Minsk"
                    },
                },
                ResponseModelType = ResponseModel.WeatherForecast,
            });

            context.ApiList.Add(new ApiModel
            {
                Title = "Coinranking API",
                RequestUrl = "https://coinranking1.p.rapidapi.com/coin/Qwsogvtv82FCd",
                BaseUrl = "coinranking1.p.rapidapi.com",
                ResponseModelType = ResponseModel.Coinranking,
            });

        context.SaveChanges();
        }
    }
}
