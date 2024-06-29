namespace WpfStudyApplication.Database.Enities
{
    public class Author
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
