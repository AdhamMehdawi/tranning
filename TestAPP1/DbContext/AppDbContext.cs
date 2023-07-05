using Microsoft.EntityFrameworkCore;

namespace TestAPP1.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Student> Students { get; set; }
        public DbSet<Domain.Entities.Account> Accounts { get; set; }
        public DbSet<Domain.Entities.StudentAccountView> StudentAccountView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.StudentAccountView>().HasNoKey().ToView("StudentAccount");
         }


    }
}
