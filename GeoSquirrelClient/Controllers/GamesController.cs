using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using GeoSquirrelClient.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace GeoSquirrelClient.Controllers
{
  [Authorize]
  public class GamesController : Controller
  {
    private readonly GeoSquirrelClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public GamesController(UserManager<ApplicationUser> userManager, GeoSquirrelClientContext database)
    {
      _userManager = userManager;
      _db = database;
    }
    public ActionResult Index()
    {
      var allGames = Game.GetGames();
      return View(allGames);
    }

    public ActionResult Details(int id)
    {
      // Viewbag.Players = new SelectList(Player.GetPlayers(), "PlayerId", "Name");
      var game = Game.GetDetails(id);
      return View(game);
    }
  
    public ActionResult Edit(int id)
    {
      var game = Game.GetDetails(id);
      return View(game);
    }

    [HttpPost]
    public ActionResult Details(int id, Game game)
    {
      game.GameId = id;
      Game.Put(game);
      return RedirectToAction("Details", id);
    }

    public ActionResult Delete(int id)
    {
      Game.Delete(id);
      return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Game game)
    {
      Game.Post(game);
      return RedirectToAction("Index");
    }
    // [HttpPost]
    // public ActionResult AddPlayer(Game game, int playerId)
    // {
    //   Game.Post(game, playerId);
    //   return RedirectToAction("Details", new {id = game.gameId});
    // }
  }
}

// // Game = flavor
// // player = treat