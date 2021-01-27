using System;

using Microsoft.EntityFrameworkCore;

namespace GeoSquirrelApi.Models
{
    public class GeoSquirrelApiContext : DbContext
    {
        public GeoSquirrelApiContext(DbContextOptions<GeoSquirrelApiContext> options)
            : base(options)
        {
        }
        public DbSet <Game> Games { get; set; }
        public DbSet<Cache> Caches { get; set; }
        public DbSet<Player> Players {get; set; }
        public DbSet<CacheGamePlayer> CacheGamePlayers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Cache>()
            .HasData(
                new Cache { CacheId = 1, Name = "Pittock Mansion", Latitude = 45.5252m, Longitude = -122.7163m, DateCreated = new DateTime(2020, 12, 1)},
                new Cache { CacheId = 2, Name = "Portland", Latitude = 45.5051m, Longitude = -122.6750m, DateCreated = new DateTime(2020, 8, 1)},
                new Cache { CacheId = 3, Name = "Location 3", Latitude = 23.88888888m, Longitude = 13.55888885m, DateCreated = new DateTime(2020, 4, 1)}
            );
        builder.Entity<Player>()
            .HasData(
                new Player { PlayerId =1, Name = "Svea", Email = "svealinneawade@gmail.com" }, 
                new Player { PlayerId = 2, Name = "Nathan", Email = "nathanschrader@icloud.com"},
                new Player { PlayerId = 3, Name = "Patrick", Email = "posten.coding@gmail.com"},
                new Player { PlayerId = 4, Name = "Randel", Email = "randel.c.moore@gmail.com"}
                );
        }
    }
    
}