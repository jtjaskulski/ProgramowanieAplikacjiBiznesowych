using Company.Intranet.Models.CMS;
using Company.Intranet.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace Company.Intranet.Data
{
    
    public class CompanyIntranetContext : DbContext
    {
        public CompanyIntranetContext(DbContextOptions<CompanyIntranetContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<News> News { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
    }
}