using Microsoft.EntityFrameworkCore;
using TestAPP1.Domain.Entities;

namespace TestAPP1.DbContext
{

    public class AppDbContext2 : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext2(DbContextOptions<AppDbContext> options) : base(options) { }
    }
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Domain.Entities.Student> Students { get; set; }
        public DbSet<Domain.Entities.Account> Accounts { get; set; }
        public DbSet<Domain.Entities.StudentAccountView> StudentAccountView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // EnitityConfiguration.ConfigureStudnet(modelBuilder);
            modelBuilder.Entity<Domain.Entities.StudentAccountView>().HasNoKey().ToView("StudentAccount");

            modelBuilder.Entity<Domain.Entities.Student>().HasData(
                new Domain.Entities.Student
                {
                    Age = 10,
                    StudentName = "Raj",
                    Email = "test@test3.com",
                    IsDeleted = true,
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 5
                });

            modelBuilder.Entity<Domain.Entities.Student>().HasMany<Account>(c => c.Account)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Domain.Entities.Student>()
                .Property(c => c.StudentName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Domain.Entities.Student>().HasQueryFilter(c => c.IsDeleted == false);

            // modelBuilder.Entity<Domain.Entities.Student>().Property(c => c.StudentName).HasColumnName("Name");

            //modelBuilder.Entity<Domain.Entities.Student>().HasKey(c => new { c.Id,c.Age });
            // modelBuilder.Entity<Domain.Entities.Student>().ToTable("Student", "test");
        }


    }

}

