using BookCatalog.Domain.Books;
using NUnit.Framework;

namespace DomainTests;

[TestFixture]
public class SpecificationTests
{
    private string _originallyPublished;
    private string _author;
    private int _pageCount;
    private IList<string> _illustrator;
    private IList<string> _genres;

    [SetUp]
    public void Setup()
    {
        _originallyPublished = "June 20, 1870";
        _author = "Jules Verne";
        _pageCount = 213;
        _illustrator = new List<string> { "Édouard Riou", "Alphonse-Marie-Adolphe de Neuville" };
        _genres = new List<string> { "Adventure fiction", "Science Fiction" };
    }

    [Test]
    public void SpecificationConstructor_ShouldInitializePropertiesCorrectly()
    {
        var specification = new Specification(
            _originallyPublished,
            _author,
            _pageCount,
            _illustrator,
            _genres
        );

        Assert.That(specification.OriginallyPublished, Is.EqualTo(_originallyPublished));
        Assert.That(specification.Author, Is.EqualTo(_author));
        Assert.That(specification.PageCount, Is.EqualTo(_pageCount));
        Assert.That(specification.Illustrator, Is.EqualTo(_illustrator));
        Assert.That(specification.Genres, Is.EqualTo(_genres));
    }

    [Test]
    public void SpecificationConstructor_ShouldNotInitializeNullLists()
    {
        var specification = new Specification(
            _originallyPublished,
            _author,
            _pageCount,
            null,
            null
        );

        Assert.That(specification.Illustrator, Is.Null);
        Assert.That(specification.Genres, Is.Null);
    }

    [Test]
    public void SpecificationConstructor_ShouldHandleEmptyLists()
    {
        var specification = new Specification(
            _originallyPublished,
            _author,
            _pageCount,
            new List<string>(),
            new List<string>()
        );

        Assert.That(specification.Illustrator, Is.Empty);
        Assert.That(specification.Genres, Is.Empty);
    }
}