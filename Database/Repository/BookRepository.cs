using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Enities;
using WpfStudyApplication.Database.Exceptions;

namespace WpfStudyApplication.Database.Repository
{
    public class BookRepository : IBookRepository
    {
        public readonly MyDbContext _context;
        public const int BatchCount = 10;

        public BookRepository(MyDbContext context)
        {
            _context = context;
        }

        public Book GetBookByName(string name)
        {
            var book = _context.Books.FirstOrDefault(x => x.Name == name);
            if (book is null)
            {
                throw new EntityNotFoundException($"Book by name ({name}) not found!");
            }
            return book;
        }

        public (int curPage, int allPage, Book[] books) GetBooksByAuthor(Author author, int page = 1)
        {
            if (page < 1)
            {
                page = 1;
            }
            var count = _context.Books.Where(x => x.AuthorId == author.Id).Count();
            int allPage = (count / BatchCount) + 1;
            if (page > allPage)
            {
                page = allPage;
            }
            var books = _context.Books.Where(x => x.AuthorId == author.Id).Skip((page - 1) * BatchCount).Take(BatchCount);
            return (page, allPage, books.ToArray());
        }

        public bool CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            //var newBook = _context.Books.FirstOrDefault(x => x.Name == book.Name && x.Description == book.Description && x.AuthorId == book.AuthorId);
            //if (newBook is null)
            //{
            //    return false;
            //}
            return true;
        }
    }
}
