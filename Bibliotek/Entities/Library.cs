namespace Bibliotek.Entities;

public class Library
{
    public IList<Book> Books { get; set; }
    public IList<Lender> Lenders { get; set; }
}