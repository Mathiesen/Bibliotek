using Bibliotek.Entities;
using Bibliotek.Service;

namespace Bibliotek
{
    public class Program
    {
        public static void Main()
        {
            var book = new Book
            {
                Id = 1,
                Name = "How to program with Ib",
                Publisher = "Ib",
                PublishedYear = 2023,
                Loaned = true
            };

            var lender = new Lender
            {
                Id = 1,
                Name = "Magnus",
                Address = "Himmelbjerget 3",
                LoanedBooks = new List<Book>{ book }
            };

            var library = new Library
            {
                Books = new List<Book> { book },
                Lenders = new List<Lender> { lender }
            };

            JsonUtils jsonUtils = new JsonUtils();
            jsonUtils.Write(library, "library.json");

            var libraryDeserialized = jsonUtils.Read("library.json");

            
            var libraryService = new LibraryService(library);
            var fetchedBook = libraryService.GetBook(1);
            Console.WriteLine(fetchedBook);

            var addBook = new Book
            {
                Id = 2,
                Name = "Programming with Erik",
                Publisher = "Erik",
                PublishedYear = 2023,
                Loaned = false
            };
            
            libraryService.AddBook(addBook);
            library.Books = libraryService.Library.Books;
            jsonUtils.Write(library, "library.json");

            var bookToUpdate = new Book { Id = 2, Loaned = true }; 
            libraryService.UpdateBook(bookToUpdate);
            
        }
    }
}

