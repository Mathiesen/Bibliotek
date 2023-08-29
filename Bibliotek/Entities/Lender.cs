namespace Bibliotek.Entities;

public class Lender
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public IList<Book> LoanedBooks { get; set; }
}