using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeoSquirrelApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
    }
}