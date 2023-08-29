using Bibliotek.Entities;
using Bibliotek.Service;

namespace BibliotekTests;

public class LibraryServiceTests
{
    private LibraryService _libraryService;
    
    [SetUp]
    public void Setup()
    {
        var books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Name = "Test book",
                PublishedYear = 2023,
                Publisher = "Test publisher",
                Loaned = false
            }
        };

        var library = new Library
        {
            Books = books
        };
        
        _libraryService = new LibraryService(library);
    }

    [Test]
    public void CanCreateNewBook()
    {
        //Arrange
        var expected = new Book
        {
            Id = 2,
            Name = "New book",
            Publisher = "New publisher",
            PublishedYear = 2023,
            Loaned = false
        };

        //Act
        _libraryService.AddBook(expected);
        var actual = _libraryService.GetBook(2);

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CanDeleteBook()
    {
        //Arrange
        var expected = _libraryService.GetBook(1);
        
        //Act
        _libraryService.DeleteBook(1);

        //Assert
        Assert.That(_libraryService.Library.Books, Has.No.Member(expected));
    }

    [Test]
    public void CanUpdateBook()
    {
        //Arrange
        var book = new Book
        {
            Id = 1,
            Loaned = true,
            Name = "Super Awesome C# Book"
        };
        
        //Act
        _libraryService.UpdateBook(book);
        var updatedBook = _libraryService.GetBook(1);

        //Assert
        Assert.True(updatedBook.Loaned);
        Assert.AreEqual("Super Awesome C# Book", updatedBook.Name);
        Assert.AreEqual(2023, updatedBook.PublishedYear);
    }
}