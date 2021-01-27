using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using GeoSquirrelClient.Models;

namespace GeoSquirrelClient.Controllers
{
  [Authorize]
  public class PlayersController : Controller
  {
    private readonly GeoSquirrelClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public PlayersController(UserManager<ApplicationUser> userManager, GeoSquirrelClientContext database)
    {
      _userManager = userManager;
      _db = database;
    }
    public ActionResult Index()
    {
      var allPlayers = Player.GetPlayers();
      return View(allPlayers);
    }
    // public IActionResult Index()
    // {
    //   var allCaches = new List<Cache>();
    //   return View(allCaches);
    // }

    [HttpPost]
    public ActionResult Index(Player player)
    {
      Player.Post(player);
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var player = Player.GetDetails(id);
      return View(cache);
    }

    public ActionResult Edit(int id)
    {
      var player = Player.GetDetails(id);
      return View(player);
    }


    [HttpPost]
    public ActionResult Details(int id, Player player)
    {
      player.PlayerId = id;
      Player.Put(player);
      return RedirectToAction("Details", id);
    }

    public ActionResult Delete(int id)
    {
      Player.Delete(id);
      return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Player player)
    {
      Player.Post(player);
      return RedirectToAction("Index");
    }
  }
}