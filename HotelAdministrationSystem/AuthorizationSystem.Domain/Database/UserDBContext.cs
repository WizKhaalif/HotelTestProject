using AuthorizationSystem.Controllers;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationSystem.Domain.Database
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
    }
}
