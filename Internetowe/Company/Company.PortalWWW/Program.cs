using Company.Data.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = ApplyBuilderPatternToBuildApp(args);
            InitializeDevelopmentEnviroment(app);
            app.UseSession();
            InitializeRoutingAndHttp(app);
            app.UseAuthorization();
            app.Run();
        }

        private static void InitializeDevelopmentEnviroment(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        }

        private static void InitializeRoutingAndHttp(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapStaticAssets();
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
        }

        private static WebApplication ApplyBuilderPatternToBuildApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CompanyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyContext")
                                     ?? throw new InvalidOperationException("Connection string 'CompanyContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            InitializeSessionInServices(builder);
            return builder.Build();
        }

        private static void InitializeSessionInServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = builder.Environment.IsDevelopment()
                    ? TimeSpan.FromSeconds(40)
                    : TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}
