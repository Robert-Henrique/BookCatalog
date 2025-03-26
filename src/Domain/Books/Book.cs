using BookCatalog.Domain.Helpers;

namespace BookCatalog.Domain.Books;

public class Book : Entity<Book>
{
    public string Name { get; protected set; }
    public decimal Price { get; protected set; }
    public Specification Specification { get; protected set; }

    public Book(int id, string name, decimal price, Specification specification)
    {
        Id = id;
        Name = name;
        Price = price;
        Specification = specification;
    }

    public decimal CalculateShipping() => Price * 0.20m;
}