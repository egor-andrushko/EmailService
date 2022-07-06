using Microsoft.AspNetCore.Mvc;
using EmailService.API.Services;
using EmailService.API.Data;

namespace EmailService.API.Controllers
{
    [ApiController]
    [Route("api-list")]
    public class ApiController : Controller
    {
        private readonly ApiService _service;
        private readonly IConfiguration _config;

        public ApiController(ApiService service)
        {
            _service = service;
            //_config = config;
            //Http
            //_config["RapidApi:ServiceApiKey"];
        }

        [HttpGet]
        public IActionResult GetApiList()
        {
            var apiList = _service.GetAll();
            return Ok(apiList);
        }

        [HttpGet("request/{id}")]
        public async Task<IActionResult> SendRequest(int id)
        {
            var response = await _service.SendRequest(id);
            return Ok(response);
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetForecast()
        {
            var forecast = await _service.SendRequest(ResponseModel.WeatherForecast);
            return Ok(forecast);
        }

    }
}
