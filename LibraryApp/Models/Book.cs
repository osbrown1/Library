using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LibraryApp.Models
{

  public class Book
  {
    public int BookId { get; set; }
    public string Title {get; set; } 
    public List<Copy> Copies {get;set;}
    [Display(Name = "Authors")]
    public List<AuthorBook> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}