using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Entity
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public static AppContext CreateAppContext(string DatabaseName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
        }
    }
}
