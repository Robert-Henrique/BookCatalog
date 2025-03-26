namespace BookCatalog.Domain.Books;

public interface IBookRepository
{
    Task<IEnumerable<Book>> SearchBooks(string term);
    Task<Book?> GetBookById(int id);
}