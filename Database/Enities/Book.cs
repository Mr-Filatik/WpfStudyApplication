using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database.Enities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }

    public static class BookExtension
    {
        public static void BookConfiguration(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasKey(x => x.Id);
            //modelBuilder.Entity<Book>().Property(x => x.Name).HasMaxLength(256);
            //modelBuilder.Entity<Book>().Property(x => x.Author).HasMaxLength(256);
            //modelBuilder.Entity<Book>()
            //    .HasOne<User>(x => x.CurrentUser)
            //    .WithOne(x => x.Book)
            //    .HasForeignKey<Book>(x => x.CurrentUserId);
        }
    }
}