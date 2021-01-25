using System;

namespace GeoSquirrelApi.Models
{
    public class Cache
    {
        public int CacheId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}