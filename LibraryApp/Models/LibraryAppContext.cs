using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
  public class LibraryAppContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<AuthorBook> AuthorBooks { get; set; }
    public DbSet<Copy> Copys { get; set; }
    public DbSet<Patron> Patrons { get; set; }
    public DbSet<PatronCopy> PatronCopys { get; set; }

    public LibraryAppContext(DbContextOptions options) : base(optoins) { }
  }
}