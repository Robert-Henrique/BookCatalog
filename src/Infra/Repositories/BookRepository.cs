using BookCatalog.Domain.Books;
using BookCatalog.Infra.Dto;
using BookCatalog.Infra.Mapper;
using System.Text.Json;

namespace BookCatalog.Infra.Repositories;

public class BookRepository : IBookRepository
{
    private readonly string _jsonFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}books.json";
    private readonly IBookMapper _bookMapper;

    public BookRepository(IBookMapper bookMapper)
    {
        _bookMapper = bookMapper;
    }

    public async Task<Book?> GetBookById(int id)
    {
        var books = await ReadBooks();
        return books.FirstOrDefault(b => b.Id == id);
    }

    public async Task<IEnumerable<Book>> SearchBooks(string term)
    {
        var books = await ReadBooks();
        return books.Where(b =>
            b.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            b.Specification.Author.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            b.Specification.Illustrator.Any(i => i.Contains(term, StringComparison.OrdinalIgnoreCase)) ||
            b.Specification.Genres.Any(g => g.Contains(term, StringComparison.OrdinalIgnoreCase))
        );
    }

    private async Task<IEnumerable<Book>> ReadBooks()
    {
        var json = await File.ReadAllTextAsync(_jsonFilePath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var booksDto = JsonSerializer.Deserialize<IEnumerable<BookDto>>(json, options);

        return booksDto.Select(_bookMapper.Mapper);
    }
}