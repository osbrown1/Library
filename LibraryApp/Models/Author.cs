using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace LibraryApp.Models
{
  public class Author
  {
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public List<AuthorBook> JoinEntities { get; }
  }
}