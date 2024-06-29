using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Enities;
using WpfStudyApplication.Database.Exceptions;

namespace WpfStudyApplication.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user is null)
            {
                throw new EntityNotFoundException($"User by Email ({email}) not found!");
            }
            return user;
        }

        public User GetUserByLastName(string lastName)
        {
            var user = _context.Users.FirstOrDefault(x => x.LastName == lastName);
            if (user is null)
            {
                throw new EntityNotFoundException($"User by LastName ({lastName}) not found!");
            }
            return user;
        }

        public User GetUserByFullName(string fullName)
        {
            string[] fn = fullName.Split(" ");
            User user = null;
            if (fn.Length == 1)
            {
                user = _context.Users.FirstOrDefault(x => x.LastName == fn[0]);
            }
            if (fn.Length == 2)
            {
                user = _context.Users.FirstOrDefault(x => x.LastName == fn[0] && x.FirstName == fn[1]);
            }
            if (fn.Length == 3)
            {
                user = _context.Users.FirstOrDefault(x => x.LastName == fn[0] && x.FirstName == fn[1] && x.Patronymic == fn[2]);
            }
            if (user is null)
            {
                throw new EntityNotFoundException($"User by fullName ({fullName}) not found!");
            }
            return user;
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            var newUser = _context.Users.FirstOrDefault(x => x.LastName == user.LastName && x.FirstName == user.FirstName && x.Patronymic == user.Patronymic && x.Email == user.Email && x.BirthDay == user.BirthDay);
            if (newUser is null)
            {
                return false;
            }
            return true;
        }
    }
}
