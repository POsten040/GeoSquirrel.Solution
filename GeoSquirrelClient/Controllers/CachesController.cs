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

namespace GeoSquirrelClient.Controllers
{
  [Authorize]
  public class CachesController : Controller
  {
    private readonly GeoSquirrelClientContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public CachesController(UserManager<ApplicationUser> userManager, GeoSquirrelClientContext database)
    {
      _userManager = userManager;
      _db = database;
    }
    public IActionResult Index()
    {
      var allCaches = Cache.GetCaches();
      return View(allCaches);
    }
    // public IActionResult Index()
    // {
    //   var allCaches = new List<Cache>();
    //   return View(allCaches);
    // }

    [HttpPost]
    public IActionResult Index(Cache cache)
    {
      Cache.Post(cache);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var cache = Cache.GetDetails(id);
      return View(cache);
    }

    public IActionResult Edit(int id)
    {
      var cache = Cache.GetDetails(id);
      return View(cache);
    }


    [HttpPost]
    public IActionResult Details(int id, Cache cache)
    {
      cache.CacheId = id;
      Cache.Put(cache);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Cache.Delete(id);
      return RedirectToAction("Index");
    }
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Cache cache)
    {
      Cache.Post(cache);
      return RedirectToAction("Index");
    }
  }
}






    // [HttpPost]
    // public IActionResult Index(Cache cache)
    // {var user = new User()
    //   {
    //     Name = "nate",
    //     Email = "someemail@email.com"
    //   };

    //   ApiHelper.AddNewUser(user);

    //   Cache.Post(cache);
    //   return RedirectToAction("Index");
    // }