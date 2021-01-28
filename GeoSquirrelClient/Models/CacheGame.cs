using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoSquirrelClient.Models
{
    public class CacheGame
    {
        public int CacheGameId { get; set; }
        public int GameId { get; set; }
        public int CacheId { get; set; }
        public Cache Cache { get; set; }

        public Game Game { get; set; }
    }
}
    