namespace Bibliotek.Entities;

public class Book
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Publisher { get; set; }
    public int? PublishedYear { get; set; }
    public bool? Loaned { get; set; }

    public override string ToString()
    {
        return $"Book with id: {Id} fetched. " +
               $"Name: {Name}, " +
               $"Publisher: {Publisher}, " +
               $"PublishedYear: {PublishedYear}, " +
               $"Loaned: {Loaned}";
    }
}