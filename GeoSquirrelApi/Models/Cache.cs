using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeoSquirrelApi.Models
{
    public class Cache
    {
        public int CacheId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        // [DisplayName]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateCreated { get; set; }
        
    }
}