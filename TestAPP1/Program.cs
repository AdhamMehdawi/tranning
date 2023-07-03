
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestAPP1.Controllers.Validation;
using TestAPP1.DbContext;
using TestAPP1.Student;

namespace TestAPP1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddFluentValidation(configuration =>
                            {
                                configuration.AutomaticValidationEnabled = false;
                            });
            //builder.Services.AddScoped<StudentOps>();
            builder.Services.AddScoped<IStudentOps, StudentOps>();
            builder.Services.AddScoped<StudentDal>();
             builder.Services.AddValidatorsFromAssemblyContaining<StudentRequestValidation>();
            builder.Services.AddScoped<IValidator<Student.Student>, StudentRequestValidation>(); 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}