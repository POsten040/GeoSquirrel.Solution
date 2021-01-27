using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeoSquirrelApi.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        // public List<Cache> CacheList { get;set;}
    }
}