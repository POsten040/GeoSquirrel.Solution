using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoSquirrelClient.Models
{
    public class CacheGamePlayer
    {
        public int CacheGamePlayerId { get; set; }
        public int PlayerId { get; set; }
        public int CacheId { get; set; }
        public int GameId { get; set; }
        public Cache Cache { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}
    