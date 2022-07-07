using EmailService.API.Data;
using System.Text;
using System.Security.Cryptography;
using EmailService.API.Models;
using Microsoft.EntityFrameworkCore;


namespace EmailService.API.Services
{
    public class UserService
    {
        private readonly ApiContext _context;

        public UserService(ApiContext context)
        {
            _context = context;
        }

        public User? GetUser(UserDto userDto)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(user => user.UserName == userDto.UserName || user.Email == userDto.Email);
        }

        public async Task<User> Create(UserDto userDto)
        {
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User();
            user.Email = userDto.Email;
            user.UserName = userDto.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
