using System.Collections.Generic;

namespace LibraryApp.Models
{

  public class Book
  {
    public int BookId { get; set; }
    public string Title {get; set; } 
    public List<Copy> Copies {get;set;}
    public List<AuthorBook> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}