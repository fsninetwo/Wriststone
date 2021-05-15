using Microsoft.EntityFrameworkCore;
using Wriststone.Models.Table;

namespace Wriststone.Models
{
    public class WriststoneContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCurrency> ProductCurrencies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<ThreadStatus> ThreadStatuses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostStatus> PostStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseNpgsql(@"host=localhost;database=wriststone;user id=postgres;password=CfrVfqVjkc1Nfqvc;");
    }
}