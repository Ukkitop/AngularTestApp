
using AngularTestApp.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.Metrics;
using AngularTestApp.Database.Interfaces;
using AngularTestApp.Database.Repository;

namespace AngularTestApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string? cs = builder.Configuration.GetConnectionString("localDb");

            builder.Services.AddDbContext<AngularTestAppDbContext>(options =>
                options.UseSqlServer(cs));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();


            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(configurePolicy: policy =>
            {
                policy.WithOrigins("https://localhost:4200");
                policy.WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS");
                policy.AllowAnyHeader();
                policy.SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<AngularTestAppDbContext>();
                try
                {
                    dataContext.Database.Migrate();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            app.Run();
        }
    }
}
