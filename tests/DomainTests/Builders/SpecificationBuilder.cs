using BookCatalog.Domain.Books;

namespace DomainTests.Builders
{
    public class SpecificationBuilder
    {
        private string _originallyPublished;
        private string _author;
        private int _pageCount;
        private IList<string> _illustrator;
        private IList<string> _genres;

        public SpecificationBuilder()
        {
            _originallyPublished = "November 25, 1864";
            _author = "Jules Verne";
            _pageCount = 183;
            _illustrator = ["Édouard Riou"];
            _genres = ["Science Fiction", "Adventure fiction"];
        }

        public static SpecificationBuilder ASpecification() => new SpecificationBuilder();

        public Specification Build() => new Specification(_originallyPublished, _author, _pageCount, _illustrator, _genres);
    }
}