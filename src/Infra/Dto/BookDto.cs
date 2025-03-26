using System.Text.Json.Serialization;

namespace BookCatalog.Infra.Dto;

public record BookDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }

    [JsonPropertyName("Specifications")]
    public SpecificationDto Specification { get; init; }

    public BookDto(int id, string name, decimal price, SpecificationDto specification)
    {
        Id = id;
        Name = name;
        Price = price;
        Specification = specification;
    }
}