using TwoFactAuth_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TwoFactAuth_WebApi.Business
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
