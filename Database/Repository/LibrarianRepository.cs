using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Enities;
using WpfStudyApplication.Database.Exceptions;

namespace WpfStudyApplication.Database.Repository
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly MyDbContext _context;

        public LibrarianRepository(MyDbContext context)
        {
            _context = context;
        }

        public Librarian LoginLibrarianByEmailAndPassword(string email, string password)
        {
            var librarian = _context.Librarians.FirstOrDefault(x => x.Email == email);
            if (librarian is null)
            {
                throw new EntityNotFoundException($"Librarian by Email ({email}) not found!");
            }
            if (librarian.Password != password)
            {
                throw new PasswordNotCorrectException($"Password for Librarian by Email ({email}) not right!");
            }
            return librarian;
        }

        public bool CreateLibrarian(Librarian librarian)
        {
            _context.Librarians.Add(librarian);
            _context.SaveChanges();
            var newLibrarian = _context.Librarians.FirstOrDefault(x => x.LastName == librarian.LastName && x.FirstName == librarian.FirstName && x.Patronymic == librarian.Patronymic && x.Email == librarian.Email && x.BirthDay == librarian.BirthDay && x.StartWorkDate == librarian.StartWorkDate);
            if (newLibrarian is null)
            {
                return false;
            }
            return true;
        }
    }
}
