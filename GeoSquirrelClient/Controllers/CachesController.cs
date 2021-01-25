using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeoSquirrelClient.Models;

namespace GeoSquirrelClient.Controllers
{
  public class CachesController : Controller
  {
    public IActionResult Index()
    {
      var allCaches = Cache.GetCaches();
      return View(allCaches);
    }
  }
}