using Microsoft.AspNetCore.Mvc;
using EmailService.API.Models;
using EmailService.API.Services;
using EmailService.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IConfiguration _config;
        private readonly string _token;
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthController(ApiContext apiContext, AuthService authService, UserService userService, IConfiguration config)
        {
            _context = apiContext;
            _config = config;
            _token = _config["App:Token"];
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserDto userDto)
        {
            var userCreated = _userService.GetUser(userDto);
            if (userCreated is not null)
            {
                if (userCreated.UserName == userDto.UserName)
                {
                    return Conflict("Username already taken.");
                }

                if (userCreated.Email == userDto.Email)
                {
                    return Conflict("Email already in use.");
                }
            }

            User user = await _userService.Create(userDto);
            string token = _authService.CreateToken(user);

            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto userDto)
        {
            var user = _userService.GetUser(userDto);
            if (user is null)
            {
                return BadRequest("User not found.");
            }

            if (!_authService.VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = _authService.CreateToken(user);
            return Ok(token);
        }
    }
}
