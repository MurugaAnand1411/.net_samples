using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleInmemoryCrud.Model;

namespace SampleInmemoryCrud.DbData
{
    public class EmployeApiDbContext : DbContext
    {
        /*protected readonly IConfiguration Configuration;
        public EmployeApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("RubixDBTest");
            options.UseSqlServer(connectionString);
        }
*/

        public EmployeApiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}


