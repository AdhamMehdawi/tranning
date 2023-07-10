
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using TestAPP1.Controllers.Validation;
using TestAPP1.Core;
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

                var jwtsConfigurationSection = builder.Configuration.GetSection("JwtSettings").GetValue<JwtSetting>("JwtSettings");
                builder.Services.AddAuthentication(config =>
                    {
                        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(c =>
                    {
                        c.TokenValidationParameters = new TokenValidationParameters()
                        {
                            RequireExpirationTime = true,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.FromSeconds(10),
                            ValidIssuer = jwtsConfigurationSection == null ? "" : jwtsConfigurationSection.Issuer,
                            ValidAudience = jwtsConfigurationSection.Audience,
                            IssuerSigningKey =
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsConfigurationSection.Key))
                        };
                        c.RequireHttpsMetadata = false;
                        c.Configuration =
                            new Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration();
                        c.Audience = jwtsConfigurationSection.Audience;
                        c.Authority = jwtsConfigurationSection.Issuer;
                        c.Events = new JwtBearerEvents()
                        {
                            OnAuthenticationFailed = context =>
                            {
                                JwtBearerEventsExtensions.OnAuthenticationFailed(context.HttpContext, "web");
                                return Task.CompletedTask;
                            }
                        };
                    })
                    .AddJwtBearer("MobileUsers", c =>
                    {
                        c.TokenValidationParameters = new TokenValidationParameters()
                        {
                            IssuerSigningKey =
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TtestKey1235841uuyyFFs!@#@##"))
                        };
                    });

                // Add services to the container.
                builder.Services.AddRin()
                    .AddEntityFrameworkCoreDiagnostics();

                builder.Services.AddControllers()
                    .AddFluentValidation(configuration => { configuration.AutomaticValidationEnabled = false; });
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

    public static class JwtBearerEventsExtensions
    {
        public static async Task OnAuthenticationFailed(HttpContext context, string schemaName)
        {
            //if (schemaName == "MobileUsers")
            //{
            //    context.Response.StatusCode = 401;
            //    context.Response.ContentType = "application/json";
            //    await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Unauthorized" }));

            //}
            //else if (schemaName == "web")
            //{
            //    context.Response.StatusCode = 401;
            //    context.Response.ContentType = "application/json";
            //    await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Unauthorized" }));

            //}
            //else
            //{
            //    context.Response.StatusCode = 401;
            //    context.Response.ContentType = "application/json";
            //    await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Unauthorized" }));

            //}
        }
    }
}