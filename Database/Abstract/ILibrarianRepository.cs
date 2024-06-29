using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database.Abstract
{
    public interface ILibrarianRepository
    {
        Librarian LoginLibrarianByEmailAndPassword(string email, string password);
        bool CreateLibrarian(Librarian librarian);
    }
}
