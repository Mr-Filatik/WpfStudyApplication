using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfStudyApplication.Database.Enities
{
    public class User : PeopleInfo
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
