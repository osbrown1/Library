using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using System.Threading.Tasks;
using LibraryApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LibraryApp.Controllers
{
  // [Authorize]
  public class AuthorsController : Controller
  {
    private readonly LibraryAppContext _db;

    public AuthorsController(LibraryAppContext db)
    {
      _db = db;
    }

    public ActionResult Create() 
    { return View(); }

    [HttpPost]
    public ActionResult Create(Author newAuthor)
    {
      _db.Authors.Add(newAuthor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Index()
    {
      return View(_db.Authors.ToList());
    }
  }

}