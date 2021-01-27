using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;


namespace GeoSquirrelClient.Models
{
  public class Cache
  {
    public int CacheId { get; set; }
    public string Name{ get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    [DisplayName("Date Created")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime DateCreated { get; set; }
    // public GeoLocation location { get; set; }
    public virtual ApplicationUser User { get; set; } 

    public static List<Cache> GetCaches()
    {
      var apiCallTask = ApiHelper.CachesGetAll();
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      Console.WriteLine(jsonResponse);
      Console.WriteLine("JSON ABOVE ABOVE ABOVE");

      List<Cache> cacheList = JsonConvert.DeserializeObject<List<Cache>>(jsonResponse.ToString());
      return cacheList;
    }

    public static Cache GetDetails(int id)
    {
      var apiCallTask = ApiHelper.CachesGet(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Cache cache = JsonConvert.DeserializeObject<Cache>(jsonResponse.ToString());

      return cache;
    }

    public static void Post(Cache cache)
    {
      string jsonCache = JsonConvert.SerializeObject(cache);
      var apiCallTask = ApiHelper.CachesPost(jsonCache);
    }

    public static void Put(Cache cache)
    {
      string jsonCache = JsonConvert.SerializeObject(cache);
      var apiCallTask = ApiHelper.Put(cache.CacheId, jsonCache);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.CachesDelete(id);
    }
  }
}