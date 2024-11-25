
using Microsoft.EntityFrameworkCore;
using Sirotti.Domus.Archimagirus.Domain.Contexts;

namespace Sirotti.Domus.Archimagirus.Api;

public class Program
{
    const string databaseConnectionStringKey = "Shared:AppSettings:SqlConnectionString";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var envName = builder.Environment.EnvironmentName;

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{envName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        if (envName == "development")
        {
            builder.Logging.AddDebug();
        }

        builder.Services
            .AddSingleton<Microsoft.Extensions.Configuration.IConfiguration>(builder.Configuration)
            .AddDbContext<RecipeContext>(options =>
            {
                string? connectionString = builder.Configuration[databaseConnectionStringKey];
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Sirotti.Domus.Archimagirus.Domain"));
            });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (envName == "development")
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            RecipeContext context = (RecipeContext)services.GetService(typeof(RecipeContext))!;
            context.Database.Migrate();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
