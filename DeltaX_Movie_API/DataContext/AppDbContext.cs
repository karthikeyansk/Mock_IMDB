using DeltaX_Movie_API.Model;
using Microsoft.EntityFrameworkCore;

namespace DeltaX_Movie_API.DataContext
{

    /// <summary>
    /// AppDbContext class
    /// </summary>
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions):base(contextOptions)
        {

        }
        public DbSet<Actor> actor { get; set; }
        public DbSet<Producer> producers { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<MovieCast> movieCasts { get; set; }



    }
}
