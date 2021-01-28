using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;


namespace GeoSquirrelClient.Models
{
  public class Game
  {
    public int GameId { get; set; }
    [DisplayName("Name: ")]
    public string Name{ get; set; } 

    public static List<Game> GetGames()
    {
      var apiCallTask = ApiHelper.GameGetAll();
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Game> gameList = JsonConvert.DeserializeObject<List<Game>>(jsonResponse.ToString());
      return gameList;
    }

    public static Game GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GameGet(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Game game = JsonConvert.DeserializeObject<Game>(jsonResponse.ToString());
      return game;
    }

    public static void Post(Game game)
    {
      string jsonGame = JsonConvert.SerializeObject(game);
      var apiCallTask = ApiHelper.GamePost(jsonGame);
    }

    public static void Put(Game game)
    {
      string jsonGame = JsonConvert.SerializeObject(game);
      var apiCallTask = ApiHelper.GamePut(game.GameId, jsonGame);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.GameDelete(id);
    }
  }
}