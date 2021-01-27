using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeoSquirrelApi.Models
{
    public class CacheGamePlayer
    {
        public int CacheGamePlayerId { get; set; }
        public int PlayerId { get; set; }
        public int CacheId { get; set; }
        public int GameId { get; set; }
        public bool FoundCache { get; set; }
        public Cache Cache { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}