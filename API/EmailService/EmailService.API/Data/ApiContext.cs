using Microsoft.EntityFrameworkCore;
using EmailService.API.Models;

namespace EmailService.API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<ApiModel> ApiList { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
