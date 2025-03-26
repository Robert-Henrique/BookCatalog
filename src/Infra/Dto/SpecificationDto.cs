using System.Text.Json.Serialization;

namespace BookCatalog.Infra.Dto;

public record SpecificationDto
{
    [JsonPropertyName("Originally published")]
    public string OriginallyPublished { get; init; }

    public string Author { get; init; }

    [JsonPropertyName("Page count")]
    public int PageCount { get; init; }

    [JsonConverter(typeof(StringOrListConverter))]
    public List<string> Illustrator { get; init; }

    [JsonConverter(typeof(StringOrListConverter))]
    public List<string> Genres { get; init; }

    public SpecificationDto(string originallyPublished, string author, int pageCount, List<string> illustrator, List<string> genres)
    {
        OriginallyPublished = originallyPublished;
        Author = author;
        PageCount = pageCount;
        Illustrator = illustrator;
        Genres = genres;
    }
}