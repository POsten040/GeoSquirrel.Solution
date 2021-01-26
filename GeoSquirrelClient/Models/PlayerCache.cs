using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoSquirrelClient.Models
{
    public class PlayerCache
    {
        public int PlayerCacheId { get; set; }
        public int PlayerId { get; set; }
        public int CacheId { get; set; }
        public Cache Cache { get; set; }
        public Player Player { get; set; }
    }
}
    