using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GeoSquirrelClient.Models
{
  public class GeoSquirrelClientContextFactory : IDesignTimeDbContextFactory<GeoSquirrelClientContext>
  {

    GeoSquirrelClientContext IDesignTimeDbContextFactory<GeoSquirrelClientContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<GeoSquirrelClientContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new GeoSquirrelClientContext(builder.Options);
    }
  }
}