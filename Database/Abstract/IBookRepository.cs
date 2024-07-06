using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database.Abstract
{
    public interface IBookRepository
    {
        Book GetBookByName(string name);
        (int curPage, int allPage, Book[] books) GetBooksByAuthor(Author author, int page = 1);
        bool CreateBook(Book book);
        bool EditBook(Book book);
        bool DeleteBook(Book book);
    }
}
