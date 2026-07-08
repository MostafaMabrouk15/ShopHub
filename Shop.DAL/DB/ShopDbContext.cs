using Microsoft.EntityFrameworkCore;
using Shop.DAL.Models;

namespace Shop.DAL.DB
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
