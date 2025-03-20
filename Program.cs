
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PetFinder.Infrastructure;
using PetFinder.Models;
using PetFinder.Repositories;
using PetFinder.Services;

namespace PetFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PetFinderContext") ?? throw new InvalidOperationException("connection string not found");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();


            builder.Services.AddDbContext<PetDbContext>(opt => opt.UseSqlServer(connectionString));
            builder.Services.AddScoped<IPetRepository, PetService>();
            builder.Services.AddScoped<IImageRepository, ImageService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrgin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            var path = Path.Combine(builder.Environment.ContentRootPath, "Uploads");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider =new PhysicalFileProvider(path),
                RequestPath = "/Resources"
            });

            app.UseCors("AllowOrgin");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

