using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeoSquirrelApi.Models
{
    public class Cache
    {
        public int CacheId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}