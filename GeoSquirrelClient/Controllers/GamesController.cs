using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using GeoSquirrelClient.Models;

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
      var allGames = Player.GetGames();
      return View(allGames);
    }
    // public IActionResult Index()
    // {
    //   var allCaches = new List<Cache>();
    //   return View(allCaches);
    // }

    [HttpPost]
    public ActionResult Index(Game game)
    {
      Game.Post(game);
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
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
  }
}