namespace BookCatalog.Domain.Books;

public class Specification
{
    public string OriginallyPublished { get; protected set; }
    public string Author { get; protected set; }
    public int PageCount { get; protected set; }
    public IList<string> Illustrator { get; protected set; }
    public IList<string> Genres { get; protected set; }

    public Specification(string originallyPublished, string author, int pageCount, IList<string> illustrator, IList<string> genres)
    {
        OriginallyPublished = originallyPublished;
        Author = author;
        PageCount = pageCount;
        Illustrator = illustrator;
        Genres = genres;
    }
}