using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System;

namespace GeoSquirrelClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

        public static async Task<string> Get(int id)
      {
        RestClient client = new RestClient("http://localhost:5000/api");
        RestRequest request = new RestRequest($"caches/{id}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }

    public static async Task Post(string newCache)
    {
      RestClient client = new RestClient("http://locahost:5000/api");
      RestRequest request = new RestRequest($"caches", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCache);
      Console.WriteLine("Hello Svea");
      Console.WriteLine(newCache);
      var response = await client.ExecuteTaskAsync(request);
      Console.WriteLine(response);
    }

    // public static async Task AddNewUser(User newUser)
    // {
    //   RestClient client = new RestClient("http://locahost:5000/api");
    //   RestRequest request = new RestRequest($"users", Method.POST);
    //   request.AddHeader("Content-Type", "application/json");
    //   request.AddJsonBody(JsonConvert.SerializeObject(newUser));
    //   var response = await client.ExecuteTaskAsync(request);
    // }

    public static async Task Put(int id, string newCache)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCache);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"caches/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}