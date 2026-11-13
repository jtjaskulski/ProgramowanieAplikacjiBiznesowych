using Company.Data.Models.CMS;
using Company.Data.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Data
{
    
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<News> News { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        //dotnet ef migrations add OrdersAndCartMigration --project Company.Data --startup-project Company.Intranet
        public DbSet<Order> Order { get; set; } = default!;
        public DbSet<OrderPosition> OrderPosition { get; set; } = default!;
        public DbSet<CartItem> CartItem { get; set; } = default!;
    }
}