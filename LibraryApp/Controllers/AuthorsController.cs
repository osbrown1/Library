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
  public class AuthorsController : Controller
  {
    private readonly LibraryAppContext _db;

    public AuthorsController(LibraryAppContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Authors.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.Books = _db.Books.ToList(); 
      return View(); 
    }

    [HttpPost]
    public ActionResult Create(string name, List<int> wutBooks)
    {
      Author newAuthor = new Author();
      newAuthor.Name = name;
      _db.Authors.Add(newAuthor);
      _db.SaveChanges();

      if(wutBooks.Count != 0)
      {
        //for every bookid in wutbooks
        foreach(int book in wutBooks)
        {//do this
          #nullable enable
          AuthorBook? joinEntity = _db.AuthorBooks.FirstOrDefault(join => (join.AuthorId == newAuthor.AuthorId && join.BookId == book));
          #nullable disable
          if (joinEntity == null)
          
           {//if it doesnt
              _db.AuthorBooks.Add(new AuthorBook() {AuthorId = newAuthor.AuthorId, BookId = book });
              _db.SaveChanges();
           }
        }
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Author thisAuthor = _db.Authors         
          .Include(author => author.JoinEntities)
          .ThenInclude(author => author.Book)
          .FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }

    public ActionResult Edit(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);

      return View(thisAuthor);
    }

    [HttpPost]
    public ActionResult Edit(Author author)
    {
      _db.Authors.Update(author);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      _db.Authors.Remove(thisAuthor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
  }

}