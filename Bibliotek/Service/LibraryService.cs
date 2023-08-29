using Bibliotek.Entities;

namespace Bibliotek.Service;

public class LibraryService
{
    private JsonUtils _jsonUtils;

    public Library Library { get; private set; }

    public LibraryService(Library library)
    {
        _jsonUtils = new JsonUtils();
        Library = library;
    }
    
    public Book GetBook(int id)
    {
        return Library.Books.Where(x => x.Id == id).FirstOrDefault() ?? new Book();
    }

    public void AddBook(Book book)
    {
        Library.Books.Add(book);
        _jsonUtils.Write(Library, "library.json");
    }

    public void DeleteBook(int id)
    {
        var book = GetBook(id);
        Library.Books.Remove(book);
    }

    public void UpdateBook(Book book)
    {
        var bookToUpdate = GetBook(book.Id.Value);

        if (book.Id != bookToUpdate.Id)
            throw new ArgumentException("It is not allowed to change the id of a book");
        
        if (book.Name != null)
            bookToUpdate.Name = book.Name;

        if (book.Loaned != null)
            bookToUpdate.Loaned = book.Loaned;

        if (book.PublishedYear != null)
            bookToUpdate.PublishedYear = book.PublishedYear;

        if (book.Publisher != null)
            bookToUpdate.Publisher = book.Publisher;
        
        _jsonUtils.Write(Library, "library.json");
    }
}