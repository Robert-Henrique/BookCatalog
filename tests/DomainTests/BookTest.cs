using BookCatalog.Domain.Books;
using DomainTests.Builders;
using ExpectedObjects;
using NUnit.Framework;

namespace DomainTests;

[TestFixture]
public class BookTests
{
    private Specification _specification;

    [SetUp]
    public void Setup()
    {
        _specification = SpecificationBuilder.ASpecification().Build();
    }

    [Test]
    public void BookConstructor_ShouldInitializePropertiesCorrectly()
    {
        var id = 1;
        var name = "Journey to the Center of the Earth";
        var price = 10.00m;
        var specification = _specification;
        var bookExpected = new
        {
            Id = id,
            Name = name,
            Price = price,
            Specification = specification
        }.ToExpectedObject();

        var book = new Book(id, name, price, specification);

        bookExpected.ShouldMatch(book);
    }

    [Test]
    public void CalculateShipping_ShouldReturnCorrectShippingAmount()
    {
        var id = 1;
        var name = "Journey to the Center of the Earth";
        var price = 10.00m;
        var specification = _specification;
        var book = new Book(id, name, price, specification);

        var shippingFee = book.CalculateShipping();

        var expectedShippingFee = price * 0.20m;
        Assert.That(shippingFee, Is.EqualTo(expectedShippingFee));
    }

    [Test]
    public void CalculateShipping_WithDifferentPrice_ShouldReturnCorrectShippingAmount()
    {
        var id = 2;
        var name = "20,000 Leagues Under the Sea";
        var price = 20.00m;
        var specification = _specification;
        var book = new Book(id, name, price, specification);

        var shippingFee = book.CalculateShipping();

        var expectedShippingFee = price * 0.20m;
        Assert.That(shippingFee, Is.EqualTo(expectedShippingFee));
    }
}