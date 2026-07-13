using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.DB;
using Shop.DAL.Models;
using Shop.DAL.Repository.Abstraction;
using Shop.DAL.Repository.Impelementation;

namespace ShopHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ShopDbContext>(option =>
              option.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnectionDB"))

            );
            //DI
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>() //UserManager,RoleManager
                .AddEntityFrameworkStores<ShopDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
