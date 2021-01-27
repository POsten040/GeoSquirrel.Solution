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
    public class GamesController : ControllerBase
    {
        private GeoSquirrelApiContext _db;
        public GamesController(GeoSquirrelApiContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get(string name)
        {
            var query = _db.Games.AsQueryable();
            if (name != null)
            {
                query = query.Where(e => e.Name == name);
            }
            Console.WriteLine("API Game Controller");
            Console.WriteLine(query);
            return query.ToList();
        }
        
        [HttpPost]
        public void Post([FromBody] Game game)
        {
            _db.Games.Add(game);
            _db.SaveChanges();
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            return _db.Games.FirstOrDefault(entry => entry.GameId == id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Game game)
        {
            game.GameId = id;
            _db.Entry(game).State = EntityState.Modified;
            _db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var gameToDelete = _db.Games.FirstOrDefault(entry => entry.GameId == id);
            _db.Games.Remove(gameToDelete);
            _db.SaveChanges();
        }
    }
}