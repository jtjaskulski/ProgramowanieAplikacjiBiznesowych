using Company.Intranet.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.Intranet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = ApplyBuilderPatternToBuildApp(args);
            InitializeDevelopmentEnviroment(app);
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
            builder.Services.AddDbContext<CompanyIntranetContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyIntranetContext")
                                     ?? throw new InvalidOperationException("Connection string 'CompanyIntranetContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            return builder.Build();
        }
    }
}
