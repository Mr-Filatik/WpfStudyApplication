using Microsoft.EntityFrameworkCore;
using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
