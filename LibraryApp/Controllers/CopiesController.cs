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

  public class CopiesController: Controller
  {
    private readonly LibraryAppContext _db;

    public CopiesController(LibraryAppContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
    ViewBag.Copies = _db.Copies.ToList();
    return View();
    }




  }
}