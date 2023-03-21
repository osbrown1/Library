using System.Collections.Generic;

namespace LibraryApp.Models
{

public class Copy
{
  public int CopyId { get; set; }
  public int BookId {get;set;}
  public Book Book {get;set;}
  public List<PatronCopy> Checkouts {get;set;}
}
}