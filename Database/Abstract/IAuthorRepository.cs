using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database.Abstract
{
    public interface IAuthorRepository
    {
        Author GetAuthorByLastName(string lastName);
        Author GetAuthorByFullName(string fullName);
        bool CreateAuthor(Author author);
    }
}
