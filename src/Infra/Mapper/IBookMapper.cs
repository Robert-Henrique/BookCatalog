using BookCatalog.Domain.Books;
using BookCatalog.Infra.Dto;

namespace BookCatalog.Infra.Mapper;

public interface IBookMapper
{
    public Book Mapper(BookDto dto);
}