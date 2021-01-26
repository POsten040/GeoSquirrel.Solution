using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeoSquirrelClient.Models
{
    public class GeoSquirrelClientContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Cache> Caches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerCache> PlayerCaches { get; set; }
        public GeoSquirrelClientContext(DbContextOptions options) : base(options)
        { }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //allows lazy loading
        // {
        // optionsBuilder.UseLazyLoadingProxies();
        // }
    }
}