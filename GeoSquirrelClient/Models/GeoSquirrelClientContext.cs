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
        public DbSet<CacheGamePlayer> CacheGamePlayers { get; set; }
        public DbSet<GamePlayer> GamePlayer { get; set; }
        public DbSet<CacheGame> CacheGame { get; set; }
        public GeoSquirrelClientContext(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        builder.Entity<Cache>()
            .HasData(
                new Cache { CacheId = 1, Name = "Pittock Mansion", Latitude = 45.5252m, Longitude = -122.7163m, DateCreated = new DateTime(2020, 12, 1)},
                new Cache { CacheId = 2, Name = "Portland", Latitude = 45.5051m, Longitude = -122.6750m, DateCreated = new DateTime(2020, 8, 1)},
                new Cache { CacheId = 3, Name = "Ireland", Latitude = 53.350140m, Longitude = -6.266155m, DateCreated = new DateTime(2020, 4, 1)},
                new Cache { CacheId = 4, Name = "Maui", Latitude = 20.798363m, Longitude = -156.331924m, DateCreated = new DateTime(2020, 4, 1)},
                new Cache { CacheId = 5, Name = "Ohio", Latitude =  40.367474m, Longitude = -82.996216m, DateCreated = new DateTime(2020, 4, 1)},
                new Cache { CacheId = 6, Name = "Russia", Latitude = 55.751244m, Longitude = 37.618423m, DateCreated = new DateTime(2020, 4, 1)},
                new Cache { CacheId = 7, Name = "Montreal", Latitude = 45.508888m, Longitude = -73.561668m, DateCreated = new DateTime(2020, 4, 1)},
                new Cache { CacheId = 8, Name = "kolkataindia", Latitude = 22.572645m, Longitude = 88.363892m, DateCreated = new DateTime(2020, 4, 1)},
                new Cache { CacheId = 9, Name = "Jabalpur", Latitude = 23.185884m, Longitude = 79.974380m, DateCreated = new DateTime(2020, 8, 1)},
                new Cache { CacheId = 10, Name = "Nigeria", Latitude = 9.0820m, Longitude = 8.6753m, DateCreated = new DateTime(2020, 8, 1)},
                new Cache { CacheId = 11, Name = "Nepal", Latitude = 28.3949m, Longitude = 84.1240m, DateCreated = new DateTime(2020, 8, 1)},
                new Cache { CacheId = 12, Name = "Toronto", Latitude = 43.651070m, Longitude = -73.561668m, DateCreated = new DateTime(2020, 4, 1)},
                new Cache { CacheId = 13, Name = "New Dehli", Latitude = 28.644800m, Longitude = -77.216721m, DateCreated = new DateTime(2020, 4, 1)}
            );
        builder.Entity<Player>()
            .HasData(
                new Player { PlayerId = 1, Name = "Svea", UserEmail = "svealinneawade@gmail.com" }, 
                new Player { PlayerId = 2, Name = "Nathan", UserEmail = "nathanschrader@icloud.com"},
                new Player { PlayerId = 3, Name = "Patrick", UserEmail = "posten.coding@gmail.com"},
                new Player { PlayerId = 4, Name = "Randel", UserEmail = "randel.c.moore@gmail.com"}
                );
        builder.Entity<Game>()
            .HasData(
                new Game { GameId = 1, Name = "Game 1"}, 
                new Game { GameId = 2, Name = "Game 2"}
                );
                
        }
    }
}