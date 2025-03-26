using BookCatalog.Domain.Books;
using BookCatalog.Infra.Dto;

namespace BookCatalog.Infra.Mapper;

public class BookMapper : IBookMapper
{
    public Book Mapper(BookDto dto)
    {
        if (dto == null) 
            throw new ArgumentNullException();

        var specification = new Specification(dto.Specification.OriginallyPublished, 
            dto.Specification.Author, 
            dto.Specification.PageCount,
            dto.Specification.Illustrator,
            dto.Specification.Genres);

        return new Book(dto.Id, dto.Name, dto.Price, specification);
    }
}