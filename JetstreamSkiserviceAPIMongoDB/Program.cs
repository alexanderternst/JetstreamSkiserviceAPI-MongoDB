using JetstreamSkiserviceAPIMongoDB.Models;
using JetstreamSkiserviceAPIMongoDB.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace JetstreamSkiserviceAPIMongoDB
{
    public class Program
    {
        /// <summary>
        /// Hauptprogramm, wo API startet, instanziierung von Services (Interfaces), Logger, JWT
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Abrufen von Loggerkonfigurationsdaten aus JSO
            var loggerFromSettings = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();

            // Logger instanziieren
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(loggerFromSettings);

            // Abrufen/Konfiguration von Datenbankeinstellungen aus JSON
            builder.Services.Configure<RegistrationDatabaseSettings>(
                builder.Configuration.GetSection("RegistrationDatabase"));

            // Add services to the container.
            builder.Services.AddScoped<IRegistrationService, RegistrationService>();
            builder.Services.AddScoped<IUserService, UserSevice>();
            builder.Services.AddScoped<IStatusService, StatusService>();

            // Hinzufügen von Services
            builder.Services.AddControllers();

            // Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jetstream Skiservice API MongoDB", Version = "v1" });
            });

            // JWT konfigurieren
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jetstream Skiservice API MongoDB v1"));
            //}

            app.UseHttpsRedirection();

            // Authentifikation instanziieren
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}