using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
      private readonly LibraryAppContext _db;

      public HomeController(LibraryAppContext db)
      {
        _db = db;
      }

      // [HttpGet("/")]
      // public ActionResult Index()
      // {
      //   Lib[] cats = _db.Categories.ToArray();
      //   Item[] items = _db.Items.ToArray();
      //   Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      //   model.Add("categories", cats);
      //   model.Add("items", items);
      //   return View(model);
      // }
    }
}