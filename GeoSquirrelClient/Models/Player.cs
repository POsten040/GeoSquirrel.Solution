using System;

namespace GeoSquirrelClient.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}