using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfStudyApplication.Database.Enities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)] 
        public string? Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public DateTime BirthDay { get; set; }

        public Book? Book { get; set; }
    }

    public class UserAdmin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
