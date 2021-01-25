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
    public class UsersController : ControllerBase
    {
    private GeoSquirrelApiContext _db;
    public UsersController(GeoSquirrelApiContext db)
    {
        _db = db;
    }
  
    
    [HttpPost]
    public void Post([FromBody] User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        return _db.Users.FirstOrDefault(entry => entry.UserId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] User user)
    {
        user.UserId = id;
        _db.Entry(user).State = EntityState.Modified;
        _db.SaveChanges();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var userToDelete = _db.Users.FirstOrDefault(entry => entry.UserId == id);
        _db.Users.Remove(userToDelete);
        _db.SaveChanges();
    }
    }
}