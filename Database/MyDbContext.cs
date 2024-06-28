using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdmin> Admins { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User[] users = new User[]
            {
                new User() { Id = 1, Name = "Vlad", Email = "1.email.com", Password = "123456", BirthDay = DateTime.UtcNow },
                new User() { Id = 2, Name = "Alex", Email = "2.email.com", Password = "123456", BirthDay = DateTime.UtcNow }
            };
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.BookConfiguration();
        }
    }
}
