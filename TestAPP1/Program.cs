
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TestAPP1.Controllers.Validation;
using TestAPP1.DbContext;
using TestAPP1.Infrastuters.LogsConfiguration;
using TestAPP1.Student;

namespace TestAPP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            { 
                StaticLogger.EnsureInitialized();

                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddRin()
                    .AddEntityFrameworkCoreDiagnostics();

                builder.Services.AddControllers()
                                .AddFluentValidation(configuration =>
                                {
                                    configuration.AutomaticValidationEnabled = false;
                                });
                //builder.Services.AddScoped<StudentOps>();
                builder.Services.AddScoped<IStudentOps, StudentOps>();
                builder.Services.AddScoped<StudentDal>();
                builder.Services.AddValidatorsFromAssemblyContaining<StudentRequestValidation>();
                builder.Services.AddScoped<IValidator<Student.StudentDto>, StudentRequestValidation>();
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
                // Add: Enable request/response recording and serve a inspector frontend.
                // Important: `UseRin` (Middlewares) must be top of the HTTP pipeline.
                app.UseRin();

                // Add: Enable Exception recorder. this handler must be after `UseDeveloperExceptionPage`.
                app.UseRinDiagnosticsHandler();

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                StaticLogger.EnsureInitialized();
                Log.Error(ex, "Error");
            }
           
        }
    }
}