using Microsoft.AspNetCore.Mvc;
using EmailService.API.Services;
using EmailService.API.Data;
using Microsoft.AspNetCore.Authorization;

namespace EmailService.API.Controllers
{
    [ApiController]
    [Route("api-list")]
    [Authorize]
    public class ApiController : Controller
    {
        private readonly ApiService _service;

        public ApiController(ApiService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetApiList()
        {
            var apiList = _service.GetAll();
            return Ok(apiList);
        }

        [HttpGet("request/{id}")]
        public async Task<IActionResult> SendRequest(int id)
        {
            var response = await _service.SendRequest(id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetForecast()
        {
            var forecast = await _service.SendRequest(ResponseModel.WeatherForecast);
            if (forecast == null)
            {
                return BadRequest();
            }
            return Ok(forecast);
        }

    }
}
