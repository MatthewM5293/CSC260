using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {

        }

        //will Create Movies Table in database using Movie.cs model
        public DbSet<Movie> Movies { get; set;} //table for db
    }
}
