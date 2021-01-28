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
    public class PlayersController : ControllerBase
    {
      private GeoSquirrelApiContext _db;
      public PlayersController(GeoSquirrelApiContext db)
      {
          _db = db;
      }
      [HttpGet]
        public ActionResult<IEnumerable<Player>> Get(string name)
        {
            var query = _db.Players.AsQueryable();
            if (name != null)
            {
                query = query.Where(e => e.Name == name);
            }
            return query.ToList();
        }
    
      
      [HttpPost]
      public void Post([FromBody] Player player)
      {
          _db.Players.Add(player);
          _db.SaveChanges();
      }

      [HttpGet("{id}")]
      public ActionResult<Player> Get(int id)
      {
          return _db.Players.FirstOrDefault(entry => entry.PlayerId == id);
      }

      [HttpPut("{id}")]
      public void Put(int id, [FromBody] Player player)
      {
          player.PlayerId = id;
          _db.Entry(player).State = EntityState.Modified;
          _db.SaveChanges();
      }
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
          var playerToDelete = _db.Players.FirstOrDefault(entry => entry.PlayerId == id);
          _db.Players.Remove(playerToDelete);
          _db.SaveChanges();
      }
    }
}
