using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeoSquirrelClient.Models
{
    public class GeoSquirrelClientContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Cache> Caches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CacheGamePlayer> CachePlayers { get; set; }
        public GeoSquirrelClientContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
        builder.Entity<Game>()
            .HasData(
                new Game { GameId =1, Name = "Game 1"}, 
                new Game { GameId = 2, Name = "Game 2"},
                );
        }
    }
}