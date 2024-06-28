using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database.Abstract
{
    public interface IUserRepository
    {
        User GetUserById(int id);
    }
}
