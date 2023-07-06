using Microsoft.EntityFrameworkCore;

namespace TestAPP1.DbContext
{
    public class EnitityConfiguration
    {
        public static void ConfigureStudnet(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Domain.Entities.StudentAccountView>().HasNoKey().ToView("StudentAccount");

            //modelBuilder.Entity<Domain.Entities.Student>().HasData(
            //    new Domain.Entities.Student
            //    {
            //        Age = 10,
            //        StudentName = "Raj",
            //        Email = ""
            //    });
        }
    }
}
