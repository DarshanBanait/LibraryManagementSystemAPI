using LibraryManagementSystemAPI.Models;
namespace LibraryManagementSystemAPI.Services
{
    public class LibraryService
    {
        private readonly List<Book> books = new();

        public IEnumerable<Book> GetAllBooks() => books;

        public IEnumerable<Book> GetBookByTitle(string title) =>
            books.Where(book => book.Title == title);

        public Book GetBookByISBN(string isbn) =>
            books.FirstOrDefault(book => book.ISBN == isbn);

        public bool AddBook(Book book)
        {
            if (books.Any(b => b.ISBN == book.ISBN))
            {
                return false; // Duplicate ISBN
            }
            books.Add(book);
            return true;
        }

        public bool UpdateBook(string isbn, Book updatedBook)
        {
            var index = books.FindIndex(book => book.ISBN == isbn);
            if (index == -1) return false; // Book not found

            books[index] = updatedBook;
            return true;
        }

        public bool RemoveBook(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null) return false; // Book not found

            books.Remove(book);
            return true;
        }

    }
}
