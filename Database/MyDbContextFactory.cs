using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WpfStudyApplication.Database
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var conn = config.GetConnectionString("SqlServerConnection");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(conn);

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
