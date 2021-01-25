using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoSquirrelClient.Models
{
  public class Cache
  {
    public int CacheId { get; set; }
    public string Name{ get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime DateCreated { get; set; }

    public static List<Cache> GetCaches()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Cache> cacheList = JsonConvert.DeserializeObject<List<Cache>>(jsonResponse.ToString());

      return cacheList;
    }
  }
}