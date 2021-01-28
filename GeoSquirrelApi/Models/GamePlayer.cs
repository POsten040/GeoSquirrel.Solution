using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoSquirrelApi.Models
{
    public class GamePlayer
    {
        public int GamePlayerId { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}