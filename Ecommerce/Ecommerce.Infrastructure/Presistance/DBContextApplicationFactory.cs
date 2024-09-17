using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Ecommerce.Infrastructure.Presistance
{
    public class DBContextApplicationFactory : IDesignTimeDbContextFactory<DBContextApplication>
    {
        public DBContextApplication CreateDbContext(string[] args)
        {
            // Build configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string from configuration
            var connnectionString = configuration.GetConnectionString("DefaultConnection");

            // Create DBContecxtOptionsBuilder with the connection string
            var optionBuilder = new DbContextOptionsBuilder<DBContextApplication>();
            optionBuilder.UseSqlServer(connnectionString); // Adjust for your database

            // Return a new intance of DBContextApplication
            return new DBContextApplication(optionBuilder.Options);
        }



    }
}
