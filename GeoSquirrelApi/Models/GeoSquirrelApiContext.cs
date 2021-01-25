using Microsoft.EntityFrameworkCore;

namespace GeoSquirrelApi.Models
{
    public class GeoSquirrelApiContext : DbContext
    {
        public GeoSquirrelApiContext(DbContextOptions<GeoSquirrelApiContext> options)
            : base(options)
        {
        }

        public DbSet<Cache> Caches { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Cache>()
            .HasData(
                new Cache { CacheId = 1, Name = "Location 1", Latitude = 17.888, Longitude = 7.555, DateCreated = ""},
                new Cache { CacheId = 1, Name = "Location 2", Latitude = 20.888, Longitude = 10.555, DateCreated = ""},
                new Cache { CacheId = 1, Name = "Location 3", Latitude = 23.888, Longitude = 13.555, DateCreated = ""},
            );
        }
    }
    
}