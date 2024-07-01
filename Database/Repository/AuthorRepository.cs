using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Enities;
using WpfStudyApplication.Database.Exceptions;

namespace WpfStudyApplication.Database.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MyDbContext _context;

        public AuthorRepository(MyDbContext context)
        {
            _context = context;
        }

        public Author GetAuthorByLastName(string lastName)
        {
            var author = _context.Author.FirstOrDefault(x => x.LastName == lastName);
            if (author is null)
            {
                throw new EntityNotFoundException($"Author by LastName ({lastName}) not found!");
            }
            return author;
        }

        public Author GetAuthorByFullName(string fullName)
        {
            string[] fn = fullName.Split(" ");
            Author author = null;
            if (fn.Length == 1)
            {
                author = _context.Author.FirstOrDefault(x => x.LastName == fn[0]);
            }
            if (fn.Length == 2)
            {
                author = _context.Author.FirstOrDefault(x => x.LastName == fn[0] && x.FirstName == fn[1]);
            }
            if (fn.Length == 3)
            {
                author = _context.Author.FirstOrDefault(x => x.LastName == fn[0] && x.FirstName == fn[1] && x.Patronymic == fn[2]);
            }
            if (author is null)
            {
                throw new EntityNotFoundException($"Author by fullName ({fullName}) not found!");
            }
            return author;
        }

        public bool CreateAuthor(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
            //var newAuthor = _context.Users.FirstOrDefault(x => x.LastName == author.LastName && x.FirstName == author.FirstName && x.Patronymic == author.Patronymic);
            //if (newAuthor is null)
            //{
            //    return false;
            //}
            return true;
        }
    }
}
