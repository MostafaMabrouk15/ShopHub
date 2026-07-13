using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Models;

namespace Shop.DAL.DB
{
    // AppDbContext : IdentityDb : DbContext  

    public class ShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
