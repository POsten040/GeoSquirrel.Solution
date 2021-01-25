using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeoSquirrelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoSquirrelApi.Controllers

{
//   [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class GeoSquirrelsController : ControllerBase
    {
    private GeoSquirrelApiContext _db;
    public GeoSquirrelsController(GeoSquirrelApiContext db)
    {
        _db = db;
    }
    
    // [HttpGet]
    // public ActionResult<IEnumerable<Cache>> Get(decimal latitude, string name)
    // {
    //   var query = _db.Caches.AsQueryable();
    //   if (latitude != null)
    //   {
    //     query = query.Where(e => e.Latitude == latitude);
    //   }
    //   if (name != null)
    //   {
    //     query = query.Where(e => e.Longitude == longitude);
    //   }
    //   return query.ToList();
    // }
    
    [HttpPost]
    public void Post([FromBody] Cache cache)
    {
        _db.Caches.Add(cache);
        _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Cache> Get(int id)
    {
        return _db.Caches.FirstOrDefault(entry => entry.CacheId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Cache cache)
    {
        cache.CacheId = id;
        _db.Entry(cache).State = EntityState.Modified;
        _db.SaveChanges();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var cacheToDelete = _db.Caches.FirstOrDefault(entry => entry.CacheId == id);
        _db.Caches.Remove(cacheToDelete);
        _db.SaveChanges();
    }
    }
}