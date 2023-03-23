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
  [Authorize]
  public class PatronsController : Controller
  {
    private readonly LibraryAppContext _db;

    public PatronsController(LibraryAppContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patrons.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.Patrons = _db.Patrons.ToList(); 
      return View(); 
    }

    [HttpPost]
    public ActionResult Create(string name, List<int> wutCopies)
    {
      Patron newPatron = new Patron();
      newPatron.Name = name;
      _db.Patrons.Add(newPatron);
      _db.SaveChanges();

      if(wutCopies.Count != 0)
      {
        //for every bookid in wutbooks
        foreach(int copy in wutCopies)
        {//do this
          #nullable enable
          PatronCopy? joinEntity = _db.PatronCopies.FirstOrDefault(join => (join.PatronId == newPatron.PatronId && join.CopyId == copy));
          #nullable disable
          if (joinEntity == null)
          
           {//if it doesnt
              _db.PatronCopies.Add(new PatronCopy() {PatronId = newPatron.PatronId, CopyId = copy });
              _db.SaveChanges();
           }
        }
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Patron thisPatron = _db.Patrons         
          .Include(patron => patron.JoinEntities)
          .ThenInclude(patron => patron.Copy)
          .FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }

    public ActionResult Edit(int id)
    {
      Patron thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);

      return View(thisPatron);
    }

    [HttpPost]
    public ActionResult Edit(Patron patron)
    {
      _db.Patrons.Update(patron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      Patron thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Patron thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
      _db.Patrons.Remove(thisPatron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // public ActionResult Delete(int id)
    // {
    //   Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
    //   return View(thisBook);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
    //   _db.Books.Remove(thisBook);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    
  }

}