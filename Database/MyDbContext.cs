using Microsoft.EntityFrameworkCore;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.LibrarianConfiguration();
            //modelBuilder.BookConfiguration();
        }
    }
}
