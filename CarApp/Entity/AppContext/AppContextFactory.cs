using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Entity
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public static AppContext CreateAppContext(string connectionType)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            string connectionString = config.GetConnectionString(connectionType);

            Console.WriteLine(connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            return new AppContext(options);
        }

        public AppContext CreateDbContext(string[] args)
        {
            return CreateAppContext("DefaultConnection");
        }
    }
}
