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
  public class BooksController : Controller
  {
    private readonly LibraryAppContext _db;

    public BooksController(LibraryAppContext db)
    {
      _db = db;
    }

    public ActionResult Create() 
    { 
      ViewBag.Authors = _db.Authors.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(string title, List<int> wutAuthors)
    {
      Book newBook = new Book();
      newBook.Title = title;
      _db.Books.Add(newBook);
      _db.SaveChanges();

      if(wutAuthors.Count != 0)
      {
        foreach(int author in wutAuthors)
        {
          _db.AuthorBooks.Add(new AuthorBook() {BookId = newBook.BookId, AuthorId = author });
          _db.SaveChanges();
        }
      }

      return RedirectToAction("Index");
    }

    public ActionResult Index()
    {
      List<Book> model = _db.Books
        .Include(thingy=>thingy.JoinEntities)
        .ThenInclude(thingy=>thingy.Author)
        .ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      Book thisBook = _db.Books
        .Include(book => book.JoinEntities)
        .ThenInclude(book => book.Author)
        .Include(book => book.Copies)
        .FirstOrDefault(item => (item.BookId == id));    
      return View(thisBook);
    }

    public ActionResult Delete(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Book thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }

}