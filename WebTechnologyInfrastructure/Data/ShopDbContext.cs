using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebTechnologyProjectCore.Entities;
using WebTechnologyProjectInfrastructure.Identity;

namespace WebTechnologyProjectInfrastructure.Data
{
    public class ShopDbContext: IdentityDbContext<User>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) 
        {
          
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<BookFeedBack> BookFeedBacks { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
