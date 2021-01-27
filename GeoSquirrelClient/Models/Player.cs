using System;

namespace GeoSquirrelClient.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ApplicationUser User { get; set; } 
        public static List<Player> GetPlayers()
        {
        var apiCallTask = ApiHelper.PlayerGetAll();
        var result = apiCallTask.Result;
        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        List<Player> playerList = JsonConvert.DeserializeObject<List<Player>>(jsonResponse.ToString());
        return playerList;
        }

        public static Player GetDetails(int id)
        {
        var apiCallTask = ApiHelper.PlayerGet(id);
        var result = apiCallTask.Result;

        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        Player player = JsonConvert.DeserializeObject<Player>(jsonResponse.ToString());

        return player;
        }

        public static void Post(Player player)
        {
        string jsonPlayer = JsonConvert.SerializeObject(player);
        var apiCallTask = ApiHelper.PlayerPost(jsonPlayer);
        }

        public static void Put(Player player)
        {
        string jsonPlayer = JsonConvert.SerializeObject(player);
        var apiCallTask = ApiHelper.PlayerPut(player.PlayerId, jsonPlayer);
        }

        public static void Delete(int id)
        {
        var apiCallTask = ApiHelper.PlayerDelete(id);
        }
    }
}