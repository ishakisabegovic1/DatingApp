using DatingAppServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingAppServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; } = default;
    }
}
