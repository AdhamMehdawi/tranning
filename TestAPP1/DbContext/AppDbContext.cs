using Microsoft.EntityFrameworkCore;

namespace TestAPP1.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Student> Students { get; set; }
        public DbSet<Domain.Entities.Account> Accounts { get; set; }
    }
}
