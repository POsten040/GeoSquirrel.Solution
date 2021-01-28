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
    public class GamePlayersController : ControllerBase
    {
        private GeoSquirrelApiContext _db;
        public GamePlayersController(GeoSquirrelApiContext db)
        {
            _db = db;
        }
        
        // [HttpGet]
        // public ActionResult<IEnumerable<GamePlayer>> Get(string gamePlayerId)
        // {
        //     var query = _db.GamePlayers.AsQueryable();
        //     if (name != null)
        //     {
        //         query = query.Where(e => e.Name == name);
        //     }
        //     return query.ToList();
        // }
        
        [HttpPost]
        public void Post([FromBody] GamePlayer gamePlayer)
        {
          Console.WriteLine("Look HERE!!!!!!!!!!!!!!!!!!!!");
          Console.WriteLine(gamePlayer);
          // if (TreatId != 0)
          // {
          //   var returnedJoin = _db.TreatFlavor.Any(join => join.FlavorId == flavor.FlavorId && join.TreatId == TreatId);
          //   if (!returnedJoin) 
          //   {
          //     _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId });
          //   }
          // }
          // _db.SaveChanges();
        }

        // [HttpGet("{id}")]
        // public ActionResult<GamePlayer> Get(int id)
        // {
        //     return _db.GamePlayers.FirstOrDefault(entry => entry.GamePlayerId == id);
        // }

        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] GamePlayer gamePlayer)
        // {
        //     gamePlayer.GamePlayerId = id;
        //     _db.Entry(gamePlayer).State = EntityState.Modified;
        //     _db.SaveChanges();
        // }
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        //     var gamePlayerToDelete = _db.Games.FirstOrDefault(entry => entry.GamePlayerId == id);
        //     _db.GamePlayers.Remove(gamePlayerToDelete);
        //     _db.SaveChanges();
        // }
    }
}