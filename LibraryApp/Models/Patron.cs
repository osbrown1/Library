using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
  public class Patron
  {
    public int PatronId {get; set; }

    public string Name { get; set; }

    public List<PatronCopy> JoinEntities { get; }

    public ApplicationUser User { get; set; } 
  }
}