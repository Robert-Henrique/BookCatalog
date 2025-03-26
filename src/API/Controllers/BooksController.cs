using BookCatalog.Domain.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    
    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> SearchBooks(string term, bool sortByPriceAscending = true)
    {
        var books = await _bookRepository.SearchBooks(term);
        var sortedBooks = sortByPriceAscending ? books.OrderBy(b => b.Price) : books.OrderByDescending(b => b.Price);
        return Ok(sortedBooks);
    }

    [HttpGet("{id}/shipping")]
    public async Task<IActionResult> CalculateShipping(int id)
    {
        var book = await _bookRepository.GetBookById(id);
        if (book == null) return NotFound();
        var shipping = book.CalculateShipping();
        return Ok(new { shipping });
    }
}