using Mapster;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SolutionOrders.Api.Features.Providers;
using SolutionOrders.Api.Features.Services;
using SolutionOrders.Data.Data;
using System.Reflection;

namespace SolutionOrders.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = UseBuilderToInitializeApp(args);
            InitializeDevelopmentEnviroment(app);
            InitializeAutomaticMigrations(app);
            ManageRoutingAndHttps(app);
            app.Run();
        }

        private static void ManageRoutingAndHttps(WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

        private static WebApplication UseBuilderToInitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            // MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Providers
            builder.Services.AddScoped<IItemProvider, ItemProvider>();

            // Services
            builder.Services.AddScoped<IItemService, ItemService>();

            // Mapster
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            builder.Services.AddOpenApi();
            return builder.Build();
        }

        private static void InitializeDevelopmentEnviroment(WebApplication app)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
        }

        private static void InitializeAutomaticMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Exception during applying the migrations.");
                }
            }
        }
    }
}
