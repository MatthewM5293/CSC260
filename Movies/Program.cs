using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Interfaces;
using Movies.Models;
using Microsoft.AspNetCore.Identity;

namespace Movies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>
                (options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //old
            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AppDbContext>();

            //new
            builder.Services.AddIdentity<IdentityUser,IdentityRole>
                (options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
            
            builder.Services.AddRazorPages();

            //movielis DAL
            builder.Services.AddTransient<IDataAccessLayer, MovieListDAL>();
            //dependency injection
            //AddTransient = creates new object
            //AddScoped = instances are created once per request
            //Singleton = same object instance

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
            app.UseAuthentication();;

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "PizzaRouteTest",
                //pattern: "pizza",
                //pattern: "pizza{id}",
                pattern: "pizza/{id?}",
                defaults: new { controller = "Home", action = "RouteTest" });
                
            app.MapControllerRoute(
                name: "LotsOfPrettyColors",
                pattern: "colors/{*colors}",
                defaults: new { controller = "Home", action = "Colors" });
                
            //catches all runtime errors in app, all unknown pages
            app.MapControllerRoute(
                name: "MattCatchAll",
                pattern: "{*bruh}",
                defaults: new { controller = "Home", action = "error" });
                

            app.Run();
        }
    }
}