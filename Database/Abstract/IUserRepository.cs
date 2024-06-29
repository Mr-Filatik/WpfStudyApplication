using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database.Abstract
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        User GetUserByLastName(string lastName);
        User GetUserByFullName(string fullName);
        bool CreateUser(User user);
    }
}
