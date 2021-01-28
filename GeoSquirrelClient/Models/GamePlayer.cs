using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace GeoSquirrelClient.Models
{
    public class GamePlayer
    {
        public int GamePlayerId { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }

        // public static List<GamePlayer> GetGamePlayers()
        // {
        // var apiCallTask = ApiHelper.GamePlayerGetAll();
        // var result = apiCallTask.Result;
        // JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        // List<GamePlayer> gamePlayerList = JsonConvert.DeserializeObject<List<GamePlayer>>(jsonResponse.ToString());
        // return gamePlayerList;
        // }
        
        
        
        // public static void Post(Game game, int PlayerId)
        // {
        //   string jsonGame = JsonConvert.SerializeObject(game, PlayerId);
        //   var apiCallTask = ApiHelper.GamePlayerPost(jsonGame);
        // }

    }
}