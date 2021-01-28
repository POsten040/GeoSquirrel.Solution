using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System;

namespace GeoSquirrelClient.Models
{
  class ApiHelper
  {
    
    public static async Task<string> CachesGetAll()
    {
      
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

      public static async Task<string> CachesGet(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task CachesPost(string newCache)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCache);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task CachesPut(int id, string newCache)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCache);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task CachesDelete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    //GAME!!!

    public static async Task<string> GameGetAll()
    {
      Console.WriteLine("GET ALL");
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"games", Method.GET);
      Console.WriteLine(request);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

      public static async Task<string> GameGet(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"games/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task GamePost(string newGame)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"games", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGame);
      var response = await client.ExecuteTaskAsync(request);
    }


    public static async Task GamePut(int id, string newGame)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"games/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGame);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task GameDelete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"games/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    //Player!!!

    public static async Task<string> PlayerGetAll()
    {
      Console.WriteLine("GET ALL");
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"players", Method.GET);
      Console.WriteLine(request);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

        public static async Task<string> PlayerGet(int id)
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"players/{id}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

    public static async Task PlayerPost(string newPlayer)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"players", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlayer);
      var response = await client.ExecuteTaskAsync(request);
    }


    public static async Task PlayerPut(int id, string newPlayer)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"players/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlayer);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PlayerDelete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"players/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }


    
  }
}