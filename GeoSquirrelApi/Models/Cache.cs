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
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Latitude { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Longitude { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}


// [Range(typeof(decimal), "0", "79228162514264337593543950335")]
// public decimal Price { get; set; }