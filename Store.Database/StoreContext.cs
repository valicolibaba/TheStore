using System.Data.Entity;
using Store.Database.Models;

namespace Store.Database
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Cart> Carts { get; set; }


        public StoreContext() : base("TheStoreDatabase")
        {
            
        }
    }
}
